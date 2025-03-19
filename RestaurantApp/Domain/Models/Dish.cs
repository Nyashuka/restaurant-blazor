namespace RestaurantApp.Domain.Models;

public class Dish : FoodItem
{
    public Dish(
        string name,
        double pricePerUnit,
        int dishCategoryId,
        int weight,
        int recommendedWeightPerPortion,
        string imageUrl) : base(name, pricePerUnit, imageUrl)
    {
        DishCategoryId = dishCategoryId;
        Weight = weight;
        RecommendedWeightPerPortion = recommendedWeightPerPortion;
    }

    public int DishCategoryId { get; private set; }
    public DishCategory? DishCategory { get; private set; }
    public int Weight { get; private set; }
    public int RecommendedWeightPerPortion { get; private set; }
}