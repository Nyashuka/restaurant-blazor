namespace RestaurantApp.Presentation.Dtos;

public class AddDishDto
{
    public string Name { get; set; } = string.Empty;
    public DishTypeDto DishType { get; set; } = new DishTypeDto();
    public int Weight { get; set; }
    public int ServingPerUnit { get; set; } = 1;
    public double PricePerUnit { get; set; }

    public List<DishIngredientDto> Ingredients { get; set; } = [];
}