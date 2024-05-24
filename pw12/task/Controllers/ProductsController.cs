using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task.Models;
using task.Service;

namespace task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var product = await _productsService.GetAllProducts();
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetSingleProduct([FromRoute] int id)
        {
            var product = await _productsService.GetSingleProduct(id);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Product>> AddProduct([FromBody] ProductDTO newProduct)
        {
            var product = await _productsService.AddProduct(newProduct);
            return Created($"~api/products/{product.Id}", product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> UpdateProduct([FromRoute] int id, [FromBody] ProductDTO updatedProduct)
        {
            var author = await _productsService.UpdateProduct(id, updatedProduct);
            if (author == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(author);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await _productsService.DeleteProduct(id);
            if (product == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(product);
        }
    }
}
