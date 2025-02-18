using RestaurantApp.Domain.Enums;

namespace RestaurantApp.Domain.Models;

public class Order
{
    public Order(int userId, int peopleCount, OrderStatusEnum status, double cost)
    {
        UserId = userId;
        PeopleCount = peopleCount;
        Status = status;
        Cost = cost;
    }

    private Order() {}

    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int PeopleCount { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public double Cost { get; private set; }
}
