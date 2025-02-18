namespace RestaurantApp.Application.Dtos;

public class CreateDishTypeDto
{
    public string Name { get; set; } = string.Empty;
    public bool IsShared { get; set; }
}