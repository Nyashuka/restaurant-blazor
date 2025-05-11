
using MudBlazor;

using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.Drinks;

public partial class DrinksPage
{
    private List<Drink> Drinks = [];
    private bool ShowDisabled { get; set; } = false;

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


    private async Task OnShowDisabledChanged(bool value)
    {
        ShowDisabled = value;
        Drinks = await DrinkService.GetAllAsync(ShowDisabled);
        StateHasChanged();
    }

    private void EditDrink(int id)
    {
        NavigationManager.NavigateTo($"chief/drinks/{id}");
    }
}