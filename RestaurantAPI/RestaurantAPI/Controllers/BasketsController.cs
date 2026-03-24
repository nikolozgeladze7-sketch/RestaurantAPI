using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Model.DTO;
using RestaurantAPI.Service;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : IdentityDbContext
    {
        private readonly IBasketService context;

        public BasketsController(IBasketService contextt)
        {
            this.context = contextt;
        }

        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket()
        {
            var basket = await context.GetBasketAsync();
            return Ok(basket);
        }

        [HttpPost("AddToBasket")]
        public async Task<IActionResult> AddToBasket([FromBody] BasketsDto item)
        {
            if (item == null)
            {
                return BadRequest("Invalid basket item.");
            }

            await context.AddToBasketAsync(item);
            return Ok("Item added to basket.");
        }

        [HttpPut("UpdateBasketItem/{dishId}")]
        public async Task<IActionResult> UpdateBasketItem(int dishId, int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0.");
            }

            await context.UpdateBasketItemAsync(dishId, quantity);
            return Ok("Basket item updated.");
        }

        [HttpDelete("RemoveFromBasket/{dishId}")]
        public async Task<IActionResult> RemoveFromBasket(int dishId)
        {
            await context.RemoveFromBasketAsync(dishId);
            return Ok("Item removed from basket.");
        }
    }
}