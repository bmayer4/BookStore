using System;
using System.Collections.Generic;
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
                return BadRequest();
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