using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task RemoveAsync(Order order);
    Task<List<Order>> GetAllAsync();
    Task<List<Order>> GetByUserIdAsync(int userId);
    Task<Dictionary<DateTime, List<Order?>>> GetUnprocessedGroupedByDateCrossing();
    Task<Order?> GetByIdAsync(int id);
}