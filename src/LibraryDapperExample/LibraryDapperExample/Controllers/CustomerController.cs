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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) => _customerService = customerService;

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateCustomerCommandRequest request)
        {
            var result = await _customerService.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteCustomerCommandRequest request)
        {
            var result = await _customerService.Delete(request);
            if (!result.Success) return BadRequest();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateCustomerCommandRequest request)
        {
            var result = await _customerService.Update(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCustomerByIdQueryRequest request)
        {
            var result = await _customerService.Get(request);
            if (!result.Success) return BadRequest();
            return Ok(result);
        }
    }
}
