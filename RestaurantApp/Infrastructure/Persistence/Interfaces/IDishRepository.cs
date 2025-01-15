using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDishRepository
{
    Task AddAsync(Dish dish);
    Task RemoveAsync(Dish dish);
    Task<List<Dish>> GetAllAsync();
    Task<Dish?> GetByIdAsync(int id);
}