using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDishTypeService
{
    Task CreateAsync(CreateDishTypeDto createDishTypeDto);
    Task RemoveAsync(int id);
    Task<List<DishType>> GetAllAsync();
}