namespace RestaurantApp.Domain.Models;

public class DishCategory
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public bool IsShared { get; private set; }

    public DishCategory(int id, string name, bool isShared)
    {
        Id = id;
        Name = name;
        IsShared = isShared;
    }

    private DishCategory() {}
}