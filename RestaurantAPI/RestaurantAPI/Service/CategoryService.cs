using RestaurantAPI.Data;
using RestaurantAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly RestaurantDbContext context;

        public CategoryService(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Categories>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Categories?> GetCategoryByIdAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }
    }
}
