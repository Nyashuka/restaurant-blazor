using MudBlazor;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.DishTypes;

public partial class DishTypesPage
{
    private List<DishType> _dishTypes = [];

    protected override async Task OnInitializedAsync()
    {
        _dishTypes = await DishTypeService.GetAllAsync();
    }

    private async Task AddNewDishType()
    {
        var result = await DialogFactory.CreateAsync<CreateDishTypeDialog>();
        if (result?.Canceled == false && result.Data is CreateDishTypeDto newDishType)
        {
            await DishTypeService.CreateAsync(newDishType);
            Snackbar.Add("Dish type added successfully!", Severity.Success);
            _dishTypes = await DishTypeService.GetAllAsync();
            StateHasChanged();
        }
    }

    private async Task DeleteItem(DishType dishType)
    {
        var result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await DishTypeService.RemoveAsync(dishType.Id);
            Snackbar.Add("Deleted!", Severity.Warning);
            _dishTypes = await DishTypeService.GetAllAsync();
            StateHasChanged();
        }
    }
}