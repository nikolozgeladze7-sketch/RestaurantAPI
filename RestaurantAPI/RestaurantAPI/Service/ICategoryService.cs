using RestaurantAPI.Model.Entities;

namespace RestaurantAPI.Service
{
    public interface ICategoryService
    {
        Task<List<Categories>> GetCategoriesAsync();
        Task<Categories> GetCategoryByIdAsync(int id);
    }
}
