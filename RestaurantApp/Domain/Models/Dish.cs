namespace RestaurantApp.Domain.Models;

public class Dish
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public Dish(int id, string name)
    {
        Id = id;
        Name = name;
    }
}