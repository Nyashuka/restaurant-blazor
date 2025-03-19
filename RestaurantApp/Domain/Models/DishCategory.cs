namespace RestaurantApp.Domain.Models;

public class DishCategory : CategoryBase
{
    public DishCategory(string name, bool isShared) : base(name, isShared)
    {
    }
}