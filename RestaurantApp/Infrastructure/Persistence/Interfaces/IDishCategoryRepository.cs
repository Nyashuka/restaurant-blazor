using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDishCategoryRepository
{
    Task AddAsync(DishCategory dishSubcategory);
    Task RemoveAsync(DishCategory dishSubcategory);
    Task<List<DishCategory>> GetAllAsync();
    Task<DishCategory?> GetByIdAsync(int id);
}