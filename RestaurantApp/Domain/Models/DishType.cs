namespace RestaurantApp.Domain.Models;

public class DishType
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public DishType(int id, string name)
    {
        Id = id;
        Name = name;
    }
}