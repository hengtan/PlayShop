using Microsoft.AspNetCore.Mvc;
using PS.Produc.API.DTOs;
using PS.Produc.API.Services.Interfaces;

namespace PS.Produc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var productsDTO = await _productService.GetProducts();

            if (productsDTO == null)
                return NotFound("Products not found");

            return Ok(productsDTO);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var productDTO = await _productService.GetProductsById(id);

            if (productDTO == null)
                return NotFound("Product not found");

            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest("Product is null");

            await _productService.AddProduct(productDTO);

            return CreatedAtRoute("GetProduct", new { id = productDTO.Id },
                               productDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, ProductDTO productDTO)
        {
            if (productDTO == null || id != productDTO.Id)
                return BadRequest("Product is null");

            var product = await _productService.GetProductsById(id);

            if (product == null)
                return NotFound("Product not found");

            await _productService.UpdateProduct(productDTO);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> DeleteProduct(int id)
        {
            var product = await _productService.GetProductsById(id);

            if (product == null)
                return NotFound("Product not found");

            await _productService.DeleteProduct(id);

            return NoContent();
        }
    }
}
