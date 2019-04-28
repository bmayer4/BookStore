using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreApp.API.Data;
using StoreApp.API.Dtos;
using StoreApp.API.Models;

namespace StoreApp.API.Controllers
{
    [Route("api/[controller]")]  // no children of users since some order will be from guests
    [ApiController]
    public class OrdersController: ControllerBase
    {
        private readonly IStoreRepository _repo;
        private readonly IMapper _mapper;

        public OrdersController(IStoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrderForUser(int id)
        {
            var authId = 0;
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out authId);

            var orderFromRepo = await _repo.GetOrder(id);

            if (orderFromRepo == null)
            {
                return BadRequest();
            };

            if (orderFromRepo.User == null || orderFromRepo.User.Id != authId)
            {
                return Unauthorized();
            }

            var authOrderToReturn = _mapper.Map<OrderForUserToReturnDto>(orderFromRepo);

            return Ok(authOrderToReturn);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrdersForUser()
        {
            var authId = 0;
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out authId);

            var user = await _repo.GetUser(authId);

            if (user == null)  
            {
                return Unauthorized();
            }

            var authOrdersFromRepo = await _repo.GetOrdersForUser(authId);

            var ordersToReturn = _mapper.Map<IEnumerable<OrderForUserToReturnDto>>(authOrdersFromRepo);

            return Ok(ordersToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderForCreationDto orderForCreationDto)
        {
            if (orderForCreationDto == null) 
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var orderEntity = _mapper.Map<Order>(orderForCreationDto);

            foreach (var item in orderEntity.OrderItems)
            {
                var bookFromRepo = await _repo.GetBook(item.BookId);

                if (bookFromRepo == null) 
                {
                    return BadRequest();
                }
            }

            if (!orderForCreationDto.Guest)
            {
                var authId = 0;
                int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out authId);
            
                var user = await _repo.GetUser(authId);

                if (user == null)  
                {
                    return Unauthorized();
                }

                orderEntity.UserId = user.Id;

                _repo.Add(orderEntity);

                if (!await _repo.SaveAll())
                {
                    throw new Exception("Failed to create order");
                }

                var authOrderToReturn = _mapper.Map<OrderForUserToReturnDto>(orderEntity);

                return CreatedAtRoute("GetOrder", new { orderId = authOrderToReturn.Id }, authOrderToReturn);
            }

            _repo.Add(orderEntity);

            if (!await _repo.SaveAll())
            {
                throw new Exception("Failed to create order");
            }

            var guestOrderToReturn = _mapper.Map<OrderForGuestToReturnDto>(orderEntity);

            return StatusCode(201, guestOrderToReturn);
        }

    }
}