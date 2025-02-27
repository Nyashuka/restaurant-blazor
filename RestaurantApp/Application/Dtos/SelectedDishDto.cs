using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class SelectedDishDto(Dish selectedDish, int count)
{
    public Dish Dish { get; set; } = selectedDish;
    public int Count { get; set; } = count;
}