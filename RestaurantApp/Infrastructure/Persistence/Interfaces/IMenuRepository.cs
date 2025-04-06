using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IMenuRepository
{
    Task AddAsync(Menu menu);
    Task RemoveAsync(Menu menu);
    Task<List<Menu>> GetAllAsync();
    Task<Menu?> GetByIdAsync(int id);
    Task<List<FoodItem>> GetFoodItemsByMenuId(int id);
}