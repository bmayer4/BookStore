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
    [Route("api/[controller]")]  
    [ApiController]
    public class BooksController: ControllerBase
    {
        private readonly IStoreRepository _repo;
        private readonly IMapper _mapper;

        public BooksController(IStoreRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var bookFromRepo = await _repo.GetBook(id);

            if (bookFromRepo == null)
            {
                return NotFound();
            }

            var bookToReturn = _mapper.Map<BookForDetailDto>(bookFromRepo);

            return Ok(bookToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var booksFromRepo = await _repo.GetBooks();

            var booksToReturn = _mapper.Map<IEnumerable<BookForListDto>>(booksFromRepo);

            return Ok(booksToReturn);
        }

        [HttpPost("{id}/review")]
        [Authorize]
        public async Task<IActionResult> AddReviewForBook(int id, [FromBody] ReviewForCreationDto reviewForCreationDto)
        {
            if (reviewForCreationDto == null) 
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var authId = 0;
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out authId);
            
            var user = await _repo.GetUser(authId);

            if (user == null)  
            {
                return Unauthorized();
            }

            var bookFromRepo = await _repo.GetBook(id);

            if (bookFromRepo == null)  
            {
                return NotFound();
            }

            if (await _repo.ReviewExists(user.Id, id))
            {
                return BadRequest("You've already reviewed this book");
            }

            var review = new Review()
            {
                UserId = user.Id,
                BookId = bookFromRepo.Id,
                Content = reviewForCreationDto.Content,
                Rating = reviewForCreationDto.Rating
            };

            _repo.Add(review);

            if (!await _repo.SaveAll())
            {
                throw new Exception($"Book review for id {id} failed on save."); 
            }
            
            return StatusCode(201);
        }

        [HttpDelete("{id}/deleteReview")]
        [Authorize]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var authId = 0;
            int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value, out authId);
            
            var user = await _repo.GetUser(authId);

            if (user == null)  
            {
                return Unauthorized();
            }

            var reviewFromRepo = await _repo.getReview(id, authId);

            if (reviewFromRepo == null)  
            {
                return NotFound();
            }

            _repo.Delete(reviewFromRepo);

            if (!await _repo.SaveAll())
            {
                throw new Exception($"Deleting review for book {id} failed on save."); 
            }
            
            return Ok();
        }

        // get all reviews by user
        // include reviews with book get


        // [Authorize]  // can delete these methods
        // [HttpPost("ForAuthor")]
        //  public async Task<IActionResult> CreateAuthor([FromBody] AuthorForCreationDto authorForCreationDto)
        // {
        //     if (!ModelState.IsValid) 
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var authorEntity = _mapper.Map<Author>(authorForCreationDto);

        //     _repo.Add(authorEntity);

        //     if (!await _repo.SaveAll())
        //     {
        //         throw new Exception("Failed to create author");
        //     }

        //     return Ok();
        // }

        // [Authorize]
        // [HttpPost("ForBook")]
        // public async Task<IActionResult> CreateBook([FromBody] BookForCreationDto bookForCreationDto)
        // {
        //     if (!ModelState.IsValid) 
        //     {
        //         return BadRequest(ModelState);
        //     }

        //     var bookEntity = _mapper.Map<Book>(bookForCreationDto);

        //     bookEntity.AuthorId = 1;

        //     _repo.Add(bookEntity);

        //     if (!await _repo.SaveAll())
        //     {
        //         throw new Exception("Failed to create book");
        //     }

        //     return Ok();
        // }
    }
}