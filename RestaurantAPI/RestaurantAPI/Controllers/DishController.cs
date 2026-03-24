using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Service;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : IdentityDbContext
    {
        private readonly IDishService context;

        public DishController(IDishService contextt)
        {
            this.context = contextt;
        }

        [HttpGet("GetFood")]
        public async Task<IActionResult> GetDish()
        {
            var food = await context.GetDishesAsync();
            return Ok(food);
        }

        [HttpGet("GetFoodById/{id}")]
        public async Task<IActionResult> GetDishById(int id)
        {
            var food = await context.GetDishByIdAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }
    }
}