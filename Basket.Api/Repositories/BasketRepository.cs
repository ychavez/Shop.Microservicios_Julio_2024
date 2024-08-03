using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.Api.Repositories
{
    public class BasketRepository(IDistributedCache distributedCache) : IBasketRepository
    {
        public async Task DeleteBasket(string username)
        {
            await distributedCache.RemoveAsync(username);
        }

        public async Task<ShoppingCart?> GetBasket(string username)
        {
            var basket = await distributedCache.GetStringAsync(username);
            
            if (basket is null) return null;

            return JsonSerializer.Deserialize<ShoppingCart>(basket);
            
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
        {
            await distributedCache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart));
            return (await GetBasket(cart.UserName))!;

        }
    }
}
