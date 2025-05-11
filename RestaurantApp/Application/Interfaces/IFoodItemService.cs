using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IFoodItemService
{
    Task<List<FoodItem>> GetEnabledByCategoryIdAsync(int categoryId);
    Task<List<FoodItem>> GetDisabledByCategoryIdAsync(int categoryId);
    Task<T> GetByIdAsync<T>(int id) where T : FoodItem;
}