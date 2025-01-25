using MudBlazor;

using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.Dishes;

public partial class DishesPage
{
    private List<Dish> Dishes = [];

    protected override async Task OnInitializedAsync()
    {
        Dishes = await DishService.GetAllAsync();
    }

    private async Task OnDeleteAsync(int id)
    {
        var result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await DishService.RemoveAsync(id);
            Snackbar.Add("Deleted!", Severity.Warning);
            Dishes = await DishService.GetAllAsync();
            StateHasChanged();
        }
    }
}