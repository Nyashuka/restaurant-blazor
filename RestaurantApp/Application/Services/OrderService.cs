
using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDayRepository _orderDayRepository;
    private readonly IOrderMenuItemRepository _orderMenuItemRepository;

    public OrderService(
        IOrderRepository orderRepository,
        IOrderDayRepository orderDayRepository,
        IOrderMenuItemRepository orderMenuItemRepository)
    {
        _orderRepository = orderRepository;
        _orderDayRepository = orderDayRepository;
        _orderMenuItemRepository = orderMenuItemRepository;
    }

    public Task CreateOrderAsync(OrderInfoDto orderInfo)
    {

        throw new NotImplementedException();
    }

    public Task<List<Order>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }
}
