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
    public int EventTypeId { get; private set; }
    public EventType EventType { get; private set; }
    public int PeopleCount { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public double Cost { get; private set; }
}
