using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDrinkService
{
    Task CreateAsync(DrinkCreatingDto drinkCreatingDto);
    Task RemoveAsync(int id);
    Task UpdateAsync(DrinkDto drinkDto);
    Task<DrinkDto> GetByIdAsync(int id);
    Task<List<Drink>> GetAllAsync(bool getDisabled = false);
    Task<List<Drink>> GetByCategoryAsync(int categoryId, bool getDisabled = false);
    Task EnableAsync(int id);
}