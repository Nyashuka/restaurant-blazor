using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDrinkCategoryService
{
    Task CreateAsync(DrinkCategoryCreatingDto drinkCategoryCreatingDto);
    Task RemoveAsync(int id);
    Task<List<DrinkCategory>> GetAllAsync();
}