
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class FoodItemService : IFoodItemService
{
    private readonly IFoodItemRepository _foodItemRepository;

    public FoodItemService(IFoodItemRepository foodItemRepository)
    {
        _foodItemRepository = foodItemRepository;
    }

    public async Task<T> GetByIdAsync<T>(int id) where T : FoodItem
    {
        var foodItem = await _foodItemRepository.GetByIdAsync(id);

        if(foodItem == null)
            throw new Exception($"FoodItem with given id({id}) is not exists!");

        if(foodItem is T castedItem)
            return castedItem;

        throw new Exception($"Incorrect data type for FoodItem cast. Check if your generic parameter is correct.");
    }

    public Task<List<FoodItem>> GetDisabledByCategoryIdAsync(int categoryId)
    {
        return _foodItemRepository.GetAllByCategoryIdAsync(categoryId, false);
    }

    public Task<List<FoodItem>> GetEnabledByCategoryIdAsync(int categoryId)
    {
        return _foodItemRepository.GetAllByCategoryIdAsync(categoryId, true);
    }
}