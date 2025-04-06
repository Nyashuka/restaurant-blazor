using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IFoodItemRepository
{
    Task<List<FoodItem>> GetAllByCategoryIdAsync(int categoryId);
    Task<FoodItem?> GetByIdAsync(int id);
}