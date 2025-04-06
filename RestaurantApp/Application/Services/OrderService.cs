using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Errors;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Enums;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;
using RestaurantApp.Presentation.Dtos;

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

    public async Task ApproveOrderAsync(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);

        if (order is null)
            throw new NullReferenceException("Order is not exists");

        var crossedOrders = await _orderRepository.GetCrossedOrdersAsync(order.Id);

        foreach(var crossedOrder in crossedOrders)
        {
            crossedOrder.ChangeStatus(OrderStatusEnum.Canceled);
            await _orderRepository.UpdateAsync(crossedOrder);
        }

        order.ChangeStatus(OrderStatusEnum.AwaitingPayment);

        await _orderRepository.UpdateAsync(order);
    }

    public async Task CreateOrderAsync(int userId, CreateOrderInfo orderInfo)
    {
        if(orderInfo.EventType == null || !orderInfo.OrderDays.Any(x => x.Date != null))
        {
            throw new Exception(ErrorMessages.OrderInfoInNotValid);
        }

        var order = new Order(userId, orderInfo.EventType.Id, null, orderInfo.GuestCount, OrderStatusEnum.Created, 0);
        await _orderRepository.AddAsync(order);

        foreach (var menuDay in orderInfo.OrderDays)
        {
            if(menuDay.Date == null)
                continue;

            var orderDay = new OrderDay(order.Id, null, (DateTime)menuDay.Date);
            await _orderDayRepository.AddAsync(orderDay);

            foreach(var menuItem in menuDay.SelectedFoodItems)
            {
                var orderMenuItem = new OrderMenuItem(orderDay.Id,menuItem.Item.Id, menuItem.Count);
                await _orderMenuItemRepository.AddAsync(orderMenuItem);
            }
        }
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public Task<Order?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Order>> GetByStatusAsync(OrderStatusEnum status)
    {
        return await _orderRepository.GetByStatusAsync(status);
    }

    public async Task<List<Order>> GetByUserIdAsync(int userId)
    {
        return await _orderRepository.GetByUserIdAsync(userId);
    }

    public async Task<List<Order>> GetCrossedOrdersAsync(int orderId)
    {
        return await _orderRepository.GetCrossedOrdersAsync(orderId);
    }

    public Task RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }
}
