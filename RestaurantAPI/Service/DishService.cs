using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data;
using RestaurantAPI.Model.Entities;

namespace RestaurantAPI.Service
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext context;

        public DishService(RestaurantDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Dishes>> GetDishesAsync()
        {
            return await context.Dishes.ToListAsync();
        }

        public async Task<Dishes?> GetDishByIdAsync(int id)
        {
            return await context.Dishes.FindAsync(id);
        }

        //ager daamate Filtri GetFiltered
    }
}
