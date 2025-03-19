using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Dtos;

public class SelectedFoodItem
{
    public SelectedFoodItem(FoodItem item, int count)
    {
        Item = item;
        Count = count;
    }

    public FoodItem Item { get; set; }
    public int Count { get; set; }
}