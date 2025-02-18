using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class CreateDishDto
{
    public string Name { get; set; } = string.Empty;
    public DishCategory? DishType { get; set; }
    public int Weight { get; set; }
    public int ServingPerUnit { get; set; } = 1;
    public double PricePerUnit { get; set; }

    public List<DishIngredientDto> Ingredients { get; set; } = [];
}