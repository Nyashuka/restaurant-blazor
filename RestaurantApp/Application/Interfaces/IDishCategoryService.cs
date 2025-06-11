using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDishCategoryService
{
    Task CreateAsync(CreateDishTypeDto createDishTypeDto);
    Task RemoveAsync(int id);
    Task DisableAsync(int id);
    Task EnableAsync(int id);
    Task UpdateAsync(int id, EditDishCategoryDto dto);
    Task<List<DishCategory>> GetAllAsync();
}