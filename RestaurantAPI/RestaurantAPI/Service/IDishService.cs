using RestaurantAPI.Model.Entities;

namespace RestaurantAPI.Service
{
    public interface IDishService
    {
        Task<List<Dishes>> GetDishesAsync();

        Task<Dishes> GetDishByIdAsync(int id);
    }
}
