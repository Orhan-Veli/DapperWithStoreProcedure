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
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService) => _managerService = managerService;

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]CreateManagerCommandRequest request)
        {
            var result = await _managerService.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateManagerCommandRequest request)
        {
            var result = await _managerService.Update(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteManagerCommandRequest request)
        {
            var result = await _managerService.Delete(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetManagerByIdQueryRequest request)
        {
            var result = await _managerService.Get(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        
    }
}
