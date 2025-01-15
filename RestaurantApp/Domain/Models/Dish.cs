namespace RestaurantApp.Domain.Models;

public class Dish
{
    public Dish(int id, string name, int dishTypeId, DishType? dishType, int weight, int servingPerUnit, double pricePerUnit)
    {
        Id = id;
        Name = name;
        DishTypeId = dishTypeId;
        DishType = dishType;
        Weight = weight;
        ServingPerUnit = servingPerUnit;
        PricePerUnit = pricePerUnit;
    }

    private Dish() {}

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int DishTypeId { get; private set; }
    public DishType? DishType { get; private set; }
    public int Weight { get; private set; }
    public int ServingPerUnit { get; private set; }
    public double PricePerUnit { get; private set; }
}