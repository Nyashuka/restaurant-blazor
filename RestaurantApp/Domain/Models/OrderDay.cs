namespace RestaurantApp.Domain.Models;

public class OrderDay
{
    public OrderDay(int orderId, Order? order, DateTime date)
    {
        OrderId = orderId;
        Order = order;
        Date = date;
    }

    private OrderDay() {}

    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public Order? Order { get; private set; }
    public DateTime Date { get; private set; }
}