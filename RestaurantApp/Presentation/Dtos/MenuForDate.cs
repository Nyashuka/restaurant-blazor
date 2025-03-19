using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Dtos;

public class MenuForDate
{
    public event Action DateChanged;

    private DateTime? _date;
    public DateTime? Date
    {
        get => _date;
        set
        {
            _date = value;
            DateChanged?.Invoke();
        }
    }

    public List<SelectedFoodItem> SelectedFoodItems { get; set; } = [];

    public MenuForDate(DateTime? date)
    {
        Date = date;
    }

    public void AddFoodItem(SelectedFoodItem selectedItem)
    {
        SelectedFoodItems.Add(selectedItem);
    }

    public void RemoveFoodItem(int id)
    {
        var foodItemToRemove = SelectedFoodItems.SingleOrDefault(x => x.Item.Id == id);

        if(foodItemToRemove != null)
            SelectedFoodItems.Remove(foodItemToRemove);
    }
}