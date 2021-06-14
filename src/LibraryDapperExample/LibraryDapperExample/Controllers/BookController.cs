using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Response;
using LibraryDapperExample.Dal.Entity;
using LibraryDapperExample.Model;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryDapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] GetAllBookQueryRequest request)
        {
            var results = _bookService.GetAll(request);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            GetByBookIdQueryRequest request = new GetByBookIdQueryRequest { Id = id };
            if (request.Id == Guid.Empty) return BadRequest();
            var result = _bookService.GetById(request);
            if (result.IsFaulted) return BadRequest();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookCommandRequest request)
        {
            var result = await _bookService.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }                 

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return NotFound();
            DeleteBookCommandRequest bookCommandRequest = new DeleteBookCommandRequest { Id = id };
            var isDeleted = await _bookService.Delete(bookCommandRequest);
            if (!isDeleted.Success) return BadRequest();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateBookCommandRequest request)
        {
            if (request == null || request.BookId == Guid.Empty) return BadRequest();
            var isUpdated = await _bookService.Update(request);
            if (!isUpdated.Success) return BadRequest();
            return Ok();
        }
    }
}
