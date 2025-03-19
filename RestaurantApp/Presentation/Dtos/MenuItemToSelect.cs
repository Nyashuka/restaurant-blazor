using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Dtos;

public class MenuItemToSelect
{
    public MenuItemToSelect(bool isSelected, FoodItem item)
    {
        IsSelected = isSelected;
        Item = item;
    }

    public bool IsSelected { get; set; }
    public FoodItem Item { get; set; }
}