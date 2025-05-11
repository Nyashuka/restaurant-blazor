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
        var result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await DishService.RemoveAsync(id);
            Snackbar.Add("Deleted!", Severity.Warning);
            Dishes = await DishService.GetAllAsync();
            StateHasChanged();
        }
    }


    private async Task OnShowDisabledChanged(bool value)
    {
        ShowDisabled = value;
        Dishes = await DishService.GetAllAsync(ShowDisabled);
        StateHasChanged();
    }


    private void EditDish(int id)
    {
        NavigationManager.NavigateTo($"chief/dishes/{id}");
    }
}