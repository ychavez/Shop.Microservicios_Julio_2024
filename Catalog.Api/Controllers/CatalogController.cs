using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class CatalogController(IProductRepository productRepository) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
            => Ok(await productRepository.GetProducts());

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] Product product)
        {
            await productRepository.CreateProduct(product);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(string id)
            =>Ok(await productRepository.DeleteProduct(id));

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Getproduct(string id) 
        {
            var product = await productRepository.GetProductById(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}
