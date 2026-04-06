using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Model.DTO;
using RestaurantAPI.Model.Entities;

namespace RestaurantAPI.Service
{
    public class BasketService : IBasketService
    {
        private readonly RestaurantDbContext context;

        public BasketService(RestaurantDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetBasket")]
        public async Task<List<BasketsDto>> GetBasketAsync()
        {
            var baskets = await context.Baskets
                .Select(b => new BasketsDto
                {
                    DishId = b.DishId,
                    Quantity = b.Quantity
                })
                .ToListAsync();

            return baskets;
        }

        [HttpPost("AddToBasket")]
        public async Task AddToBasketAsync(BasketsDto basketItem)
        {
            var item = new Basket
            {
                DishId = basketItem.DishId,
                Price = basketItem.Price,
                Quantity = basketItem.Quantity
            };

            await context.Baskets.AddAsync(item);
            await context.SaveChangesAsync();
        }

        [HttpPut("UpdateBasketItem")]
        public async Task UpdateBasketItemAsync(int dishId, int quantity)
        {
            var basketItem = await context.Baskets.FirstOrDefaultAsync(x => x.DishId == dishId);

            if (basketItem != null)
            {
                basketItem.Quantity = quantity;
                await context.SaveChangesAsync();
            }
        }


        [HttpDelete("DeleteBasket")]
        public async Task RemoveFromBasketAsync(int dishId)
        {
            var item = await context.Baskets.FirstOrDefaultAsync(x => x.DishId == dishId);

            if (item != null)
            {
                context.Baskets.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        [HttpDelete("ClearBasket")]
        public async Task ClearBasketAsync()
        {
            var items = await context.Baskets.ToListAsync();

            context.Baskets.RemoveRange(items);

            await context.SaveChangesAsync();
        }
    }
}
