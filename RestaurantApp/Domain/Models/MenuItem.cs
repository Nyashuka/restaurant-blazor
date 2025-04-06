namespace RestaurantApp.Domain.Models;

public class MenuItem
{
    public int Id { get; private set; }
    public int MenuId { get; private set; }
    public Menu? Menu { get; private set;}
    public int FoodItemId { get; private set; }
    public FoodItem? FoodItem { get; private set; }

    private MenuItem() {}

    public MenuItem(int menuId, int foodItemId)
    {
        MenuId = menuId;
        FoodItemId = foodItemId;
    }
}