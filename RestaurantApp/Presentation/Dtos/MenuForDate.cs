using RestaurantApp.Application.Dtos;

namespace RestaurantApp.Presentation.Dtos;

public class MenuForDate
{
    public DateTime? Date { get; set; }
    public List<SelectedDishDto> SelectedDishes { get; set; } = [];

    public MenuForDate(DateTime? date)
    {
        Date = date;
    }

    public void AddDish(SelectedDishDto selectedDishDto)
    {
        SelectedDishes.Add(selectedDishDto);
    }
}