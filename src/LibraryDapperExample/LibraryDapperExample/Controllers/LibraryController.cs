using LibraryDapperExample.Business.Abstract;
using LibraryDapperExample.Dal.Dapper.EntityFramework.Commands.Request;
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
        public async Task<IActionResult> Create(CreateLibraryCommandRequest request)
        {
            var result = await _libraryService.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }
    }
}
