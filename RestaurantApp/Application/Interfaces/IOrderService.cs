using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(OrderInfoDto orderInfo);
    Task RemoveAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
}