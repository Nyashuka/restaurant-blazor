using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class DishDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CategoryBase? Category { get; set; }
    public int Weight { get; set; }
    public int RecommendedWeightPerPerson { get; set; } = 1;
    public double PricePerUnit { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public List<DishIngredient> Ingredients { get; set; } = [];
}