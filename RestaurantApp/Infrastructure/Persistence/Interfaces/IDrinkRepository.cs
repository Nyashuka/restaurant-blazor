using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IDrinkRepository
{
    Task AddAsync(Drink drink);
    Task RemoveAsync(Drink drink);
    Task<List<Drink>> GetAllAsync(bool getDisabled);
    Task<List<Drink>> GetByCategoryAsync(int categoryId, bool getDisabled);
    Task<Drink?> GetByIdAsync(int id);
    Task UpdateAsync(Drink drink);
}