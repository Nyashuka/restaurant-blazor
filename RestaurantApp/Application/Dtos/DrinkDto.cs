using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class DrinkDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CategoryBase? Category { get; set; }
    public int Volume { get; set; }
    public int VolumePerPerson { get; set; }
    public bool IsAlcoholic { get; set; }
    public double PricePerUnit { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}