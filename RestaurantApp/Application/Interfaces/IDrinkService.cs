using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDrinkService
{
    Task CreateAsync(DrinkCreatingDto drinkCreatingDto);
    Task RemoveAsync(int id);
    Task<Drink?> GetByIdAsync(int id);
    Task<List<Drink>> GetAllAsync();
    Task<List<Drink>> GetByCategoryAsync(int categoryId);
}