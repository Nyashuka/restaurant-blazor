using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Dtos;

public class OrderDayDto
{
    private DateTime? date;

    public event Action DateChanged = null!;

    public void SetSelectedFoods(List<OrderMenuItem> selectedFoods)
    {
        SelectedFoodItems = [];
        foreach (OrderMenuItem item in selectedFoods)
        {
            AddFoodItem(item.FoodItem, item.Count);
        }
    }

    public OrderDayDto(DateTime? date)
    {
        Date = date;
    }

    public DateTime? Date
    {
        get { return date; }
        set
        {
            date = value;
            DateChanged?.Invoke();
        }
    }
    public List<SelectedFoodItem> SelectedFoodItems { get; set; } = [];

    public void AddFoodItem(FoodItem item, int count)
    {
        SelectedFoodItems.Add(new SelectedFoodItem(item, count));
    }

    public void RemoveFoodItemById(int id)
    {
        var foodItemToRemove = SelectedFoodItems.SingleOrDefault(x => x.Item.Id == id);

        if(foodItemToRemove != null)
            SelectedFoodItems.Remove(foodItemToRemove);
    }
}
