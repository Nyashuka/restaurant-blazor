using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDishService
{
    Task CreateAsync(CreateDishDto createDishDto);
    Task RemoveAsync(int id);
    Task UpdateAsync(DishDto dishDto);
    Task<DishDto> GetByIdAsync(int id);
    Task<List<Dish>> GetAllAsync(bool getDisabled = false);
    Task<List<Dish>> GetByCategoryAsync(int categoryId);
}