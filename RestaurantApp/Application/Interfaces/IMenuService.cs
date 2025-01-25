using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IMenuService
{
    Task CreateAsync(CreateMenuDto createDishDto);
    Task RemoveAsync(int id);
    Task<List<Menu>> GetAllAsync();
}