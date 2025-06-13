﻿
using RestaurantApp.Domain.Enums;

namespace RestaurantApp.Domain.Models;

public class Order
{
    public Order(int userId, int eventTypeId, EventType eventType, int peopleCount, OrderStatusEnum status, double cost)
    {
        UserId = userId;
        EventTypeId = eventTypeId;
        EventType = eventType;
        PeopleCount = peopleCount;
        Status = status;
        Cost = cost;
    }

    private Order() {}

    public int Id { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }
    public int EventTypeId { get; private set; }
    public EventType EventType { get; private set; }
    public int PeopleCount { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public double Cost { get; private set; }
    public ICollection<OrderDay> OrderDays { get; private set; } = [];

    public void ChangeStatus(OrderStatusEnum newStatus)
    {
        if (!IsValidStatusChange(newStatus))
        {
            throw new InvalidOperationException($"Cannot change status from {Status} to {newStatus}");
        }

        Status = newStatus;
    }

    private bool IsValidStatusChange(OrderStatusEnum newStatus)
    {
        return Status switch
        {
            OrderStatusEnum.Created =>
                newStatus is OrderStatusEnum.AwaitingPayment or OrderStatusEnum.Canceled,

            OrderStatusEnum.AwaitingPayment =>
                newStatus is OrderStatusEnum.Confirmed or OrderStatusEnum.Canceled,

            OrderStatusEnum.Confirmed =>
                newStatus is OrderStatusEnum.Completed or OrderStatusEnum.Canceled,

            _ => false
        };
    }

    public void Update(int eventTypeId, int orderInfoGuestCount, double cost)
    {
        EventTypeId = eventTypeId;
        PeopleCount = orderInfoGuestCount;
        Cost = cost;
        OrderDays = [];
    }
}
