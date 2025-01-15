using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDishTypeRepository
{
    Task AddAsync(DishType dishType);
    Task RemoveAsync(DishType dishType);
    Task<List<DishType>> GetAllAsync();
    Task<DishType?> GetByIdAsync(int id);
}