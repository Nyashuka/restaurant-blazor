using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class DrinkCreatingDto
{
    public string Name { get; set; }
    public DrinkCategory? Category { get; set; }
    public int Volume { get; set; }
    public int VolumePerPerson { get; set; }
    public bool IsAlcoholic { get; set; }
    public double PricePerUnit { get; set; }
    public string ImageUrl { get; set; }
}