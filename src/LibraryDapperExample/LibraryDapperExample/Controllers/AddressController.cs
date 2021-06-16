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
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService) => _addressService = addressService;

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateAddressCommandRequest request)
        {
            var result = await _addressService.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateAddressCommandRequest request)
        {
            var result = await _addressService.Update(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]DeleteAddressCommandRequest request)
        {
            var result = await _addressService.Delete(request);
            if (!result.Success) return BadRequest();
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllAddressQueryRequest request)
        {
            var result = await _addressService.GetAll(request);
            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAddressByIdQueryRequest request)
        {
           var result = await _addressService.Get(request);
            if (!result.Success) return BadRequest();
            return Ok(result.Data);

        }     
    }
}
