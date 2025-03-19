using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Dtos;

public class DrinkToSelect
{
    public bool IsSelected { get; set; }
    public Drink Drink { get; set; }
}