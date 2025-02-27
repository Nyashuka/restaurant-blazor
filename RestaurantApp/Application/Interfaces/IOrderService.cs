using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int userId, OrderInfoDto orderInfo);
    Task RemoveAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task<List<Order>> GetByUserIdAsync(int userId);
    Task<Order?> GetByIdAsync(int id);
}