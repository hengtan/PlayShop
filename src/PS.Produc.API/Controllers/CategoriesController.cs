using Microsoft.AspNetCore.Mvc;
using PS.Produc.API.DTOs;
using PS.Produc.API.Services.Interfaces;

namespace PS.Produc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            var categoriesDTO = await _categoryService.GetCategories();

            if (categoriesDTO == null)
                return NotFound("Categories not found");

            return Ok(categoriesDTO);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriesDTO = await _categoryService.GetCategoriesProducts();

            if (categoriesDTO == null)
                return NotFound("Products/Categories not found");

            return Ok(categoriesDTO);
        }


        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var categoryDTO = await _categoryService.GetCategoryById(id);

            if (categoryDTO == null)
                return NotFound("Category not found");

            return Ok(categoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
                return BadRequest("Category is null");

            await _categoryService.AddCategory(categoryDTO);

            return CreatedAtRoute("GetCategory", new { id = categoryDTO.CategoryId },
                categoryDTO);
        }

        [HttpPut("{id:int}")]  
        public async Task<ActionResult> UpdateCategory (int id,
            [FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)            
                return BadRequest("Category is null");            

            if (id != categoryDTO.CategoryId)            
                return BadRequest("Category ID mismatch");            

            try
            {
                await _categoryService.UpdateCategory(categoryDTO);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Consider using a logging framework like Serilog or NLog here
                // _logger.LogError(ex, "An error occurred while updating the category.");
                return StatusCode(500, "An error occurred while updating the category.");
            }

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory(int id)
        {
            var categoryDTO = await _categoryService.GetCategoryById(id);

            if (categoryDTO == null)
            {
                return NotFound("Category not found");
            }

            try
            {
                await _categoryService.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                // Consider using a logging framework like Serilog or NLog here
                // _logger.LogError(ex, "An error occurred while deleting the category.");
                return StatusCode(500, "An error occurred while deleting the category.");
            }

            return Ok(categoryDTO);
        }
        
    }
}
