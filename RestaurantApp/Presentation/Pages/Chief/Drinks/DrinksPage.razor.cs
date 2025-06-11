
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
        var result = await DialogFactory.CreateAsync<ConfirmationDialog>();

        if (result?.Canceled == false)
        {
            await DrinkService.RemoveAsync(id);
            Snackbar.Add("Вимкнено!", Severity.Warning);
            await UpdateDrinks();
        }
    }

    private async Task OnEnableAsync(int id)
    {
        var result = await DialogFactory.CreateAsync<ConfirmationDialog>();

        if (result?.Canceled == false)
        {
            await DrinkService.EnableAsync(id);
            Snackbar.Add("Успішно відновлено!", Severity.Success);
            await UpdateDrinks();
        }
    }

    private async Task UpdateDrinks()
    {
        Drinks = await DrinkService.GetAllAsync(ShowDisabled);
        StateHasChanged();
    }


    private async Task OnShowDisabledChanged(bool value)
    {
        ShowDisabled = value;
        await UpdateDrinks();
    }

    private void EditDrink(int id)
    {
        NavigationManager.NavigateTo($"chief/drinks/{id}");
    }
}