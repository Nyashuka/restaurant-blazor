using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class SelectedDishDto
{
    public Dish? Dish { get; set; }
    public int Count { get; set; }

    public SelectedDishDto(Dish? selectedDish, int count)
    {
        Dish = selectedDish;
        Count = count;
    }
}