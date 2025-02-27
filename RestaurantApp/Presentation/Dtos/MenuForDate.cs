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

    public void RemoveDish(int id)
    {
        var dishToRemove = SelectedDishes.SingleOrDefault(x => x.Dish.Id == id);

        if(dishToRemove != null)
            SelectedDishes.Remove(dishToRemove);
    }
}