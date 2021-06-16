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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]CreateCategoryCommandRequest request)
        {
          var result = await _categoryService.Create(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateCategoryCommandRequest request)
        {
            var result = await _categoryService.Update(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]DeleteCategoryCommandRequest request)
        {
            var result = await _categoryService.Delete(request);
            if (!result.Success) return BadRequest();
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllCategoryQueryRequest request)
        {
            var result = await _categoryService.GetAll(request);
            if (!result.Success) return BadRequest();
            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Get(GetCategoryByIdQueryRequest request)
        {
            var result = await _categoryService.Get(request);
            if (!result.Success) return BadRequest();
            return Ok(result.Data);
        }
    }
}
