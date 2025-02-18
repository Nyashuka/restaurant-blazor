using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IOrderDayRepository
{
    Task AddAsync(OrderDay orderDay);
    Task RemoveAsync(OrderDay orderDay);
    Task<List<OrderDay>> GetAllAsync();
    Task<OrderDay?> GetByIdAsync(int id);
}