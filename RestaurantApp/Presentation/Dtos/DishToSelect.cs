using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Dtos;

public class DishToSelect
{
    public bool IsSelected { get; set; }
    public Dish Dish { get; set; }
}