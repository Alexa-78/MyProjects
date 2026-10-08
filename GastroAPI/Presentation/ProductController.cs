using GastroAPI.Application.Interfaces;
using GastroAPI.Application.Services;
using GastroAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GastroAPI.Presentation
{
        [Route("api/[controller]")]
        [ApiController]
        public class ProductController : ControllerBase
        {
            private readonly ProductService _productService;
            public ProductController(ProductService productService)
            {
                _productService = productService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Product>>> Get()
            {
                var products = await _productService.GetProductsAsync();
                return Ok(products);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Product>> GetProduct(int id)
            {
                var product = await _productService.GetProductAsync(id);
                if (product == null) return NotFound();
                return Ok(product);
            }

            [HttpPost]
            public async Task<ActionResult<Product>> Create([FromBody] Product product)
            {
                var created = await _productService.CreateProductAsync(product);
                return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, created);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult<Product>> Update(int id, [FromBody] Product product)
            {
                var updated = await _productService.UpdateProductAsync(id, product);
                if (updated == null) return NotFound();
                return Ok(updated);
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(int id)
            {
                var deleted = await _productService.DeleteProductAsync(id);
                if (!deleted) return NotFound();
                return NoContent();
            }
        }   
}
