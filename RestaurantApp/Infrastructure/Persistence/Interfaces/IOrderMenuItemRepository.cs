using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IOrderMenuItemRepository
{
    Task AddAsync(OrderMenuItem item);
    Task RemoveAsync(OrderMenuItem item);
    Task<List<OrderMenuItem>> GetAllAsync();
    Task<List<OrderMenuItem>> GetAllByOrderDayIdAsync(int orderDayId);
    Task<OrderMenuItem?> GetByIdAsync(int id);
}