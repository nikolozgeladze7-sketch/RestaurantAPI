using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Model.Entities;

namespace RestaurantAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(RestaurantDbContext context) : ControllerBase
    {
        private readonly RestaurantDbContext context = context;

        [HttpGet("GetFood")]
        public async Task<IActionResult> GetFood()
        {
            var food = await context.Product.ToListAsync();
            return Ok(food);
        }

        [HttpGet("GetFoodById/{id}")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            var food = await context.Product.FirstOrDefaultAsync(x => x.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        [HttpPost("AddFood")]
        public async Task<IActionResult> AddFood(Model.Entities.Product newProduct)
        {
            Product product = new Product();
            product.Id = newProduct.Id;
            product.Name = newProduct.Name;
            product.Price = newProduct.Price;
            product.Nuts = newProduct.Nuts;
            product.Image = newProduct.Image;
            product.Vegetarian = newProduct.Vegetarian;
            product.Spiciness = newProduct.Spiciness;
            product.CategoryId = newProduct.CategoryId;

            await context.Product.AddAsync(product);
            await context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("UpdateFood/{id}")]
        public async Task<IActionResult> UpdateFood(int id, Model.Entities.Product product)
        {
            if (id != product.Id) 
            {
                return BadRequest();
            } 
            context.Product.Update(product);
            await context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("DeleteFood/{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var food = await context.Product.FirstOrDefaultAsync(x => x.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            context.Product.Remove(food);
            await context.SaveChangesAsync();
            return Ok(food);
        }
    }
}
