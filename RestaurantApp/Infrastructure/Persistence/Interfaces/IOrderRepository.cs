using RestaurantApp.Domain.Enums;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task RemoveAsync(Order order);
    Task UpdateAsync(Order order);
    Task<List<Order>> GetAllAsync();
    Task<List<Order>> GetByUserIdAsync(int userId);
    Task<List<Order>> GetByStatusAsync(OrderStatusEnum status);
    Task<List<Order>> GetCrossedOrdersAsync(int orderId);
    Task<Dictionary<DateTime, List<Order?>>> GetUnprocessedGroupedByDateCrossing();
    Task<Order?> GetByIdAsync(int id);
}