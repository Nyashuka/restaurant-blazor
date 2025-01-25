namespace RestaurantApp.Domain.Models;

public class MenuItem
{
    public int Id { get; private set; }
    public int MenuId { get; private set; }
    public Menu? Menu { get; private set;}
    public int DishId { get; private set; }
    public Dish? Dish { get; private set; }

    private MenuItem() {}

    public MenuItem(int id, int menuId, Menu? menu, int dishId, Dish? dish)
    {
        Id = id;
        MenuId = menuId;
        Menu = menu;
        DishId = dishId;
        Dish = dish;
    }
}