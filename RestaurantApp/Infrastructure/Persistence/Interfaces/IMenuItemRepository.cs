using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IMenuItemRepository
{
    Task AddAsync(MenuItem menuItem);
    Task AddRangeAsync(List<MenuItem> menuItems);
    Task RemoveAsync(MenuItem menuItem);
    Task<List<MenuItem>> GetAllAsync();
    Task<MenuItem?> GetByIdAsync(int id);
}