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
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writer;
        public WriterController(IWriterService writer) => _writer = writer;

        [HttpPost]
        public async Task<IActionResult> Create(CreateWriterCommandRequest request)
        {
            var result = await _writer.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateWriterCommandRequest request)
        {
            var result = await _writer.Update(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteWriterCommandRequest request)
        {
            var result = await _writer.Delete(request);
            if (!result.Success) return BadRequest();
            return NoContent();
        }
    }
}
