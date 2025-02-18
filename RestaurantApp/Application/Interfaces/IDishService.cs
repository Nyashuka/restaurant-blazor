using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDishService
{
    Task CreateAsync(CreateDishDto createDishDto);
    Task RemoveAsync(int id);
    Task<Dish?> GetByIdAsync(int id);
    Task<List<Dish>> GetAllAsync();
    Task<List<Dish>> GetByCategoryAsync(int categoryId);
}