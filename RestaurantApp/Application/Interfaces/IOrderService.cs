using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Enums;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int userId, OrderInfoDto orderInfo);
    Task RemoveAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task ApproveOrderAsync(int orderId);
    Task<List<Order>> GetCrossedOrdersAsync(int orderId);
    Task<List<Order>> GetByStatusAsync(OrderStatusEnum status);
    Task<List<Order>> GetByUserIdAsync(int userId);
    Task<Order?> GetByIdAsync(int id);
}