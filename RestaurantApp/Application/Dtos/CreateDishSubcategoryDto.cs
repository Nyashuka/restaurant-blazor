using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class CreateDishSubcategoryDto
{
    public string Name { get; set; }
    public DishCategory Category { get; set; }
}