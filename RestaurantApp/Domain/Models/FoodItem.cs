namespace RestaurantApp.Domain.Models;

public abstract class FoodItem
{
    protected FoodItem() { }

    protected FoodItem(string name, double pricePerUnit, int categoryId, string imageUrl)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        CategoryId = categoryId;
        ImageUrl = imageUrl;
    }

    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public double PricePerUnit { get; protected set; }
    public int CategoryId { get; protected set; }
    public CategoryBase Category { get; protected set; }
    public string ImageUrl { get; protected set; }
    public bool IsEnabled { get; protected set; } = true;
}