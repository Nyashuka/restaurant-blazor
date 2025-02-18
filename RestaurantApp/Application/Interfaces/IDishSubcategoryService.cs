using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IDishSubcategoryService
{
    Task CreateAsync(CreateDishSubcategoryDto createDishSubcategoryDto);
    Task RemoveAsync(int id);
    Task<List<DishSubcategory>> GetAllAsync();
}