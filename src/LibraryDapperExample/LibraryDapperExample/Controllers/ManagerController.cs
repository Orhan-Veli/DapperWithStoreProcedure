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
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ManagerController(IManagerService managerService) => _managerService = managerService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateManagerCommandRequest request)
        {
            var result = await _managerService.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateManagerCommandRequest request)
        {
            var result = await _managerService.Update(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        
    }
}
