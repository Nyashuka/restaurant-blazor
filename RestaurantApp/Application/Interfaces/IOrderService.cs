using RestaurantApp.Domain.Enums;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dtos;

namespace RestaurantApp.Application.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int userId, CreateOrderInfo orderInfo);
    Task RemoveAsync(int id);
    Task<List<Order>> GetAllAsync();
    Task ApproveOrderAsync(int orderId);
    Task<List<Order>> GetCrossedOrdersAsync(int orderId);
    Task<List<Order>> GetByStatusAsync(OrderStatusEnum status);
    Task<List<Order>> GetByUserIdAsync(int userId);
    Task<Order?> GetByIdAsync(int id);
}