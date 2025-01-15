using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Chief.Dishes;

public partial class DishesPage
{
    private List<Dish> Dishes = [];

    protected override async Task OnInitializedAsync()
    {
        Dishes = await DishService.GetAllAsync();
    }
}