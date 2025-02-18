using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDishRepository
{
    Task AddAsync(Dish dish);
    Task RemoveAsync(Dish dish);
    Task<List<Dish>> GetAllAsync();
    Task<List<Dish>> GetByCategoryAsync(int categoryId);
    Task<Dish?> GetByIdAsync(int id);
}