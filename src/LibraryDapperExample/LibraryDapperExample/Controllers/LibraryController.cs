using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Queries.Request;
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
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService) => _libraryService = libraryService;
        
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]CreateLibraryCommandRequest request)
        {
            var result = await _libraryService.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]DeleteLibraryCommandRequest request)
        {
            var result = await _libraryService.Delete(request);
            if (!result.Success) return BadRequest();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery]UpdateLibraryCommandRequest request)
        {
            var result = await _libraryService.Update(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetLibraryByIdQueryRequest request)
        {
            var result = await _libraryService.Get(request);
            if (!result.Success) return BadRequest();
            return Ok(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllLibraryQueryRequest request)
        {
            var result = await _libraryService.GetAll(request);
            return Ok(result.Data);
        }
    }
}
