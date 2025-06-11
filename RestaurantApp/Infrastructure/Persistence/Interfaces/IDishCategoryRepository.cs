using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDishCategoryRepository
{
    Task AddAsync(DishCategory dishCategory);
    Task RemoveAsync(DishCategory dishCategory);
    Task UpdateAsync(DishCategory dishCategory);
    Task<List<DishCategory>> GetAllAsync();
    Task<DishCategory?> GetByIdAsync(int id);
}