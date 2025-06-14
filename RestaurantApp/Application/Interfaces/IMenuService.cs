using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Dtos.Editing;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IMenuService
{
    Task CreateAsync(CreateMenuDto createDishDto);
    Task RemoveAsync(int id);
    Task<List<Menu>> GetAllAsync();
    Task<Menu?> GetByIdAsync(int id);
    Task<List<MenuItem>> GetMenuItemsByMenuId(int id);
    Task<List<FoodItem>> GetFoodItemsByMenuId(int id);
    Task UpdateAsync(EditMenuDto menuEditingDto);
}