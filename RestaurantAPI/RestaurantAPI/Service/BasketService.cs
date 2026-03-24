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
        public async Task<List<Baskets>> GetBasketAsync()
        {
            return await context.Baskets.ToListAsync();
        }

        [HttpPost("AddToBasket")]
        public async Task AddToBasketAsync(Baskets basketItem)
        {
            await context.Baskets.AddAsync(basketItem);
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
            var basketItem = await context.Baskets
                .FirstOrDefaultAsync(x => x.DishId == dishId);

            if (basketItem != null)
            {
                context.Baskets.Remove(basketItem);
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

        public async Task AddToBasketAsync(BasketsDto basketItem)
        {
            var item = new Baskets
            {
                DishId = basketItem.DishId,
                Quantity = basketItem.Quantity
            };

            await context.Baskets.AddAsync(item);
            await context.SaveChangesAsync();
        }

        //esec gaakete
        Task<List<BasketsDto>> IBasketService.GetBasketAsync()
        {
            throw new NotImplementedException();
        }
    }
}
