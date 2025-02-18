namespace RestaurantApp.Domain.Models;

public class DishSubcategory
{
    public DishSubcategory(string name, int categoryId, DishCategory? category)
    {
        Name = name;
        CategoryId = categoryId;
        Category = category;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int CategoryId { get; private set; }
    public DishCategory? Category { get; private set; }

    private DishSubcategory() {}
}