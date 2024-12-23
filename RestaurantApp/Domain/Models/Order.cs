using RestaurantApp.Domain.Enums;

namespace RestaurantApp.Domain.Models;

public class Order
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public DateTime Date { get; private set; }
    public int PeopleCount { get; private set; }
    public OrderStatusEnum Status { get; private set; }
    public int Count { get; private set; }
}
