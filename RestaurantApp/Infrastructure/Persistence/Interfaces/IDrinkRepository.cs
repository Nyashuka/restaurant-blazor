using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDrinkRepository
{
    Task AddAsync(Drink drink);
    Task RemoveAsync(Drink drink);
    Task<List<Drink>> GetAllAsync();
    Task<List<Drink>> GetByCategoryAsync(int categoryId);
    Task<Drink?> GetByIdAsync(int id);
}