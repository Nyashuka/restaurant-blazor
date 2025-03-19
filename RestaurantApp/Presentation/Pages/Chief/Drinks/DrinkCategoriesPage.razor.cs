using MudBlazor;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.Drinks;

public partial class DrinkCategoriesPage
{
    private List<DrinkCategory> DrinkCategories = [];

    protected override async Task OnInitializedAsync()
    {
        DrinkCategories = await DrinkCategoryService.GetAllAsync();
    }

    private async Task AddNewDishType()
    {
        var result = await DialogFactory.CreateAsync<DrinkCategoryCreatingDialog>();
        if (result?.Canceled == false && result.Data is DrinkCategoryCreatingDto newCategory)
        {
            await DrinkCategoryService.CreateAsync(newCategory);
            Snackbar.Add("Dish type added successfully!", Severity.Success);
            DrinkCategories = await DrinkCategoryService.GetAllAsync();
            StateHasChanged();
        }
    }

    private async Task DeleteItem(DrinkCategory category)
    {
        var result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await DrinkCategoryService.RemoveAsync(category.Id);
            Snackbar.Add("Deleted!", Severity.Warning);
            DrinkCategories = await DrinkCategoryService.GetAllAsync();
            StateHasChanged();
        }
    }
}