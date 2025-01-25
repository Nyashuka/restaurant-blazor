namespace RestaurantApp.Domain.Models;

public class OrderMenuItem
{
    public int Id { get; private set; }
    public int OrderId { get; private set; }
    public int DishId { get; private set; }
    public int Count { get; private set; }
}