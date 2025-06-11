using MudBlazor;

using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.Dishes;

public partial class DishesPage
{
    private List<Dish> Dishes = [];
    private bool ShowDisabled { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        Dishes = await DishService.GetAllAsync();
    }

    private async Task OnDeleteAsync(int id)
    {
        var result = await DialogFactory.CreateAsync<ConfirmationDialog>();

        if (result?.Canceled == false)
        {
            await DishService.RemoveAsync(id);
            Snackbar.Add("Deleted!", Severity.Warning);
            Dishes = await DishService.GetAllAsync();
            StateHasChanged();
        }
    }

    private async Task OnEnableAsync(int id)
    {
        var result = await DialogFactory.CreateAsync<ConfirmationDialog>();

        if (result?.Canceled == false)
        {
            await DishService.EnableAsync(id);
            Snackbar.Add("Успішно відновлено!", Severity.Success);
            await UpdateDishList();
        }
    }

    private async Task UpdateDishList()
    {
        Dishes = await DishService.GetAllAsync(ShowDisabled);
        StateHasChanged();
    }

    private async Task OnShowDisabledChanged(bool value)
    {
        ShowDisabled = value;
        await UpdateDishList();
    }


    private void EditDish(int id)
    {
        NavigationManager.NavigateTo($"chief/dishes/{id}");
    }
}