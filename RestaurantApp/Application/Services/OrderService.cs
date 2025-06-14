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
    private readonly IFoodItemRepository _foodItemRepository;

    public OrderService(
        IOrderRepository orderRepository,
        IOrderDayRepository orderDayRepository,
        IOrderMenuItemRepository orderMenuItemRepository,
        IFoodItemRepository foodItemRepository)
    {
        _orderRepository = orderRepository;
        _orderDayRepository = orderDayRepository;
        _orderMenuItemRepository = orderMenuItemRepository;
        _foodItemRepository = foodItemRepository;
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

    public async Task PayForOrder(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);

        if (order is null)
            throw new NullReferenceException("Order is not exists");

        order.ChangeStatus(OrderStatusEnum.Confirmed);

        await _orderRepository.UpdateAsync(order);
    }

    public async Task CreateOrderAsync(int userId, CreateOrderInfo orderInfo)
    {
        if(orderInfo.EventType == null || !orderInfo.OrderDays.Any(x => x.Date != null))
        {
            throw new Exception(ErrorMessages.OrderInfoInNotValid);
        }

        double costs = await GetOrderCosts(orderInfo);
        var order = new Order(userId, orderInfo.EventType.Id, null, orderInfo.GuestCount, OrderStatusEnum.Created, costs);
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

    public async Task<double> GetOrderCosts(CreateOrderInfo orderInfo)
    {
        double costs = 0;

        foreach(var orderDay in orderInfo.OrderDays)
        {
            foreach(var orderItem in orderDay.SelectedFoodItems)
            {
                var foodItem = await _foodItemRepository.GetByIdAsync(orderItem.Item.Id);

                if (foodItem == null)
                    throw new Exception("FoodItem for order costs calculation is not found!");

                costs += orderItem.Count * foodItem.PricePerUnit;
            }
        }

        return costs;
    }

    public async Task<double> GetOrderCosts(Order order)
    {
        double costs = 0;



        return costs;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _orderRepository.GetAllAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
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

    public async Task<List<DateTime>> GetBookedDays()
    {
        var orderDays = await _orderDayRepository.GetAllAsync();
        return orderDays
            .Where(x => x.Date.Date > DateTime.Today.Date
                && IsBookedStatus(x.Order.Status))
            .Select(x => x.Date.ToLocalTime().Date).ToList();
    }

    public bool IsBookedStatus(OrderStatusEnum status)
    {
        return status == OrderStatusEnum.Confirmed || status == OrderStatusEnum.AwaitingPayment;
    }

    public async Task DeclineOrderAsync(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);

        if (order is null)
            throw new NullReferenceException("Order is not exists");

        order.ChangeStatus(OrderStatusEnum.Canceled);

        await _orderRepository.UpdateAsync(order);
    }

    public async Task CompleteOrderAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id);

        if (order is null)
            throw new NullReferenceException("Order is not exists");

        order.ChangeStatus(OrderStatusEnum.Completed);

        await _orderRepository.UpdateAsync(order);
    }

    public async Task UpdateOrderAsync(int userId, int orderId, CreateOrderInfo orderInfo)
    {
        var orderToUpdate = await _orderRepository.GetByIdAsync(orderId);
        
        if(orderToUpdate is null)
            throw new NullReferenceException("Order is not exists");
        
        if(orderInfo.EventType == null || !orderInfo.OrderDays.Any(x => x.Date != null))
        {
            throw new Exception(ErrorMessages.OrderInfoInNotValid);
        }

        foreach (var orderDay in orderToUpdate.OrderDays.ToList())
        {
            await _orderDayRepository.RemoveAsync(orderDay);
        }
        
        double costs = await GetOrderCosts(orderInfo);
        orderToUpdate.Update(orderInfo.EventType.Id, orderInfo.GuestCount, costs);
        await _orderRepository.UpdateAsync(orderToUpdate);

        foreach (var menuDay in orderInfo.OrderDays)
        {
            if(menuDay.Date == null)
                continue;

            var orderDay = new OrderDay(orderToUpdate.Id, null, (DateTime)menuDay.Date);
            await _orderDayRepository.AddAsync(orderDay);

            foreach(var menuItem in menuDay.SelectedFoodItems)
            {
                var orderMenuItem = new OrderMenuItem(orderDay.Id, menuItem.Item.Id, menuItem.Count);
                await _orderMenuItemRepository.AddAsync(orderMenuItem);
            }
        } 
    }
}
