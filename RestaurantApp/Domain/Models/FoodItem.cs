namespace RestaurantApp.Domain.Models;

public abstract class FoodItem
{
    protected FoodItem() { }

    protected FoodItem(string name, double pricePerUnit, string imageUrl)
    {
        Name = name;
        PricePerUnit = pricePerUnit;
        ImageUrl = imageUrl;
    }

    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public double PricePerUnit { get; protected set; }
    public string ImageUrl { get; protected set; }
}