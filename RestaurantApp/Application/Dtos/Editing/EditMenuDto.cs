using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos.Editing;

public class EditMenuDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int EventTypeId { get; set; }
    public EventType? EventType { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public List<Drink> Drinks { get; set; } = [];
    public List<Dish> Dishes { get; set; } = [];
}