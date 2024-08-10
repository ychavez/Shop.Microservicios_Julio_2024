using Basket.Api.Entities;
using Basket.Api.Repositories;
using EventBus.Mesagges.Events;
using Inventory.Grpc.Protos;
using MassTransit;
using Microsoft.AspNetCore.Mvc;


namespace Basket.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController(IBasketRepository basketRepository,
        Existence.ExistenceClient existenceClient, IPublishEndpoint publishEndpoint) : ControllerBase
    {

        [HttpPost("Checkout")]
        public async Task<ActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            var basket = await basketRepository.GetBasket(basketCheckout.UserName);

            if (basket is null)
                return BadRequest();

            var eventMessage = new BasketCheckoutEvent
            {
                Address = basketCheckout.Address,
                FirstName = basketCheckout.FirstName,
                LastName = basketCheckout.LastName,
                PaymentMehod = basketCheckout.PaymentMethod,
                UserName = basket.UserName,
                TotalPrice = basketCheckout.TotalPrice
            };

            await publishEndpoint.Publish(eventMessage);

            await basketRepository.DeleteBasket(basketCheckout.UserName);

            return Accepted();
        }





        [HttpGet("{userName}")]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await basketRepository.GetBasket(userName);

            return Ok(basket ?? new(userName));

        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.CartItems)
            {
                var existence = await existenceClient.checkExistenceAsync(new() { Id = item.ProductId });

                item.Quantity = item.Quantity > existence.ProductQty ? existence.ProductQty : item.Quantity;

            }

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
