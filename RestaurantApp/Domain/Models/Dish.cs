namespace RestaurantApp.Domain.Models;

public class Dish
{
    public Dish(int id, string name, int dishCategoryId, DishCategory? dishCategory, int weight, int recommendedWeightPerPortion, double pricePerUnit)
    {
        Id = id;
        Name = name;
        DishCategoryId = dishCategoryId;
        DishCategory = dishCategory;
        Weight = weight;
        RecommendedWeightPerPortion = recommendedWeightPerPortion;
        PricePerUnit = pricePerUnit;
    }

    private Dish() {}

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int DishCategoryId { get; private set; }
    public DishCategory? DishCategory { get; private set; }
    public int Weight { get; private set; }
    public int RecommendedWeightPerPortion { get; private set; }
    public double PricePerUnit { get; private set; }
}