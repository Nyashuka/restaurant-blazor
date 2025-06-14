
namespace RestaurantApp.Domain.Models;

public class Dish : FoodItem
{
    protected Dish()
    {}

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
    public List<DishIngredient> Ingredients { get; private set; }

    public void Update(string name, int weight, int recommendedWeightPerPortion, double pricePerUnit, CategoryBase category, string imageUrl)
    {
        Name = name;
        Weight = weight;
        RecommendedWeightPerPortion = recommendedWeightPerPortion;
        PricePerUnit = pricePerUnit;
        CategoryId = category.Id;
        Category = null;
        ImageUrl = imageUrl;
        Ingredients = null;
    }
}