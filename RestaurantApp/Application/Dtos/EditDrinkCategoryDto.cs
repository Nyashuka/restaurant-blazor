namespace RestaurantApp.Application.Dtos;

public class EditDrinkCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsShared { get; set; }
}