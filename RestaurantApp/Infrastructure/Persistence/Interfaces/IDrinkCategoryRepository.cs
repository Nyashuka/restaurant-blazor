using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDrinkCategoryRepository
{
    Task AddAsync(DrinkCategory category);
    Task RemoveAsync(DrinkCategory category);
    Task<List<DrinkCategory>> GetAllAsync();
    Task<DrinkCategory?> GetByIdAsync(int id);
    Task UpdateAsync(DrinkCategory category);
}