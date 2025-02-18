namespace RestaurantApp.Domain.Models;

public class OrderMenuItem
{
    public OrderMenuItem(int orderDayId, OrderDay? orderDay, int dishId, Dish? dish, int count)
    {
        OrderDayId = orderDayId;
        OrderDay = orderDay;
        DishId = dishId;
        Dish = dish;
        Count = count;
    }

    private OrderMenuItem() {}

    public int Id { get; private set; }
    public int OrderDayId { get; private set; }
    public OrderDay? OrderDay { get; private set; }
    public int DishId { get; private set; }
    public Dish? Dish { get; private set; }
    public int Count { get; private set; }
}