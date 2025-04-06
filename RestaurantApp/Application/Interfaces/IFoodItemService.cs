using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IFoodItemService
{
    Task<List<FoodItem>> GetByCategoryIdAsync(int categoryId);
    Task<T> GetByIdAsync<T>(int id) where T : FoodItem;
}