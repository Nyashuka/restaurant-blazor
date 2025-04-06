namespace RestaurantApp.Domain.Models;

public class Dish : FoodItem
{
    public Dish(
        string name,
        double pricePerUnit,
        int categoryId,
        int weight,
        int recommendedWeightPerPortion,
        string imageUrl) : base(name, pricePerUnit, categoryId, imageUrl)
    {
        Weight = weight;
        RecommendedWeightPerPortion = recommendedWeightPerPortion;
    }

    public int Weight { get; private set; }
    public int RecommendedWeightPerPortion { get; private set; }
}