using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDishCategoryService
{
    Task CreateAsync(CreateDishTypeDto createDishTypeDto);
    Task RemoveAsync(int id);
    Task<List<DishCategory>> GetAllAsync();
}