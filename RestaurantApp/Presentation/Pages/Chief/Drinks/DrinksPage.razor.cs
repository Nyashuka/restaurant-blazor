
using MudBlazor;

using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.Drinks;

public partial class DrinksPage
{
    private List<Drink> Drinks = [];

    protected override async Task OnInitializedAsync()
    {
        Drinks = await DrinkService.GetAllAsync();
    }

    private async Task OnDeleteAsync(int id)
    {
        var result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await DrinkService.RemoveAsync(id);
            Snackbar.Add("Deleted!", Severity.Warning);
            Drinks = await DrinkService.GetAllAsync();
            StateHasChanged();
        }
    }
}