using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController (IBasketRepository basketRepository) : ControllerBase
    {
        [HttpGet("{userName}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await basketRepository.GetBasket(userName);
            
            return Ok(basket ?? new(userName));

        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>>
            UpdateBasket([FromBody] ShoppingCart shoppingCart)
        {
            await basketRepository.UpdateBasket(shoppingCart);
            return Ok(shoppingCart);
        
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult> DeleteBasket(string userName) 
        {
            await basketRepository.DeleteBasket(userName);
            return NoContent();
        }

    }
}
