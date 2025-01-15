namespace RestaurantApp.Domain.Models;

public class DishIngredient
{
    public DishIngredient(int id, int dishId, Dish? dish, string name, int weight)
    {
        Id = id;
        DishId = dishId;
        Dish = dish;
        Name = name;
        Weight = weight;
    }

    private DishIngredient() {}

    public int Id { get; private set; }
    public int DishId { get; private set; }
    public Dish? Dish { get; private set; }
    public string Name { get; private set; }
    public int Weight { get; private set; }
}