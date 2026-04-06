using RestaurantAPI.Model.DTO;

namespace RestaurantAPI.Service
{
    public interface IBasketService
    {
        Task<List<BasketsDto>> GetBasketAsync();
        Task AddToBasketAsync(BasketsDto basketItem);
        Task UpdateBasketItemAsync(int dishId, int quantity);
        Task RemoveFromBasketAsync(int dishId);
        Task ClearBasketAsync();
    }
}
