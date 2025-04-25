namespace RestaurantApp.Domain.Models;

public abstract class CategoryBase
{
    public int Id { get; protected set; }
    public string Name { get; protected set; } = string.Empty;
    public bool IsShared { get; protected set; }
    public bool IsEnabled { get; protected set; } = true;

    public CategoryBase(string name, bool isShared)
    {
        Name = name;
        IsShared = isShared;
    }

    protected CategoryBase() {}
}