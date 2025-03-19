namespace RestaurantApp.Domain.Models;

public class OrderMenuItem
{
    public OrderMenuItem(int orderDayId, int foodItemId, int count)
    {
        OrderDayId = orderDayId;
        Count = count;
        FoodItemId = foodItemId;
    }

    private OrderMenuItem() {}

    public int Id { get; private set; }
    public int OrderDayId { get; private set; }
    public OrderDay? OrderDay { get; private set; }
    public int FoodItemId { get; private set; }
    public FoodItem? FoodItem { get; private set; }
    public int Count { get; private set; }
}