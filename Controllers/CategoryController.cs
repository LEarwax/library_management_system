using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using library_management_system.Services.CategoryService;
using library_management_system.Dtos.Category;

namespace library_management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetCategoryDto>>> GetAsync()
        {
            return Ok(await _categoryService.GetCategoriesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCategoryDto>> GetOneAsync(int id)
        {
            return Ok(await _categoryService.GetCategoryByIDAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<GetCategoryDto>> AddCategoryAsync([FromBody] AddCategoryDto newCategory)
        {
            return Ok(await _categoryService.AddCategoryAsync(newCategory));
        }

        [HttpPut]
        public async Task<ActionResult<GetCategoryDto>> UpdateCategoryAsync([FromBody] UpdateCategoryDto updatedCategory)
        {
            return Ok(await _categoryService.UpdateCategoryAsync(updatedCategory));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCategoryAsync(int id)
        {
            return Ok(await _categoryService.DeleteCategoryAsync(id));
        }
    }
}