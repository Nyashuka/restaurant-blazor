using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class CreateMenuDto
{
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public EventType? EventType { get; set; }
    public List<Dish> Dishes { get; set; } = [];
    public List<Drink> Drinks { get; set; } = [];
}