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
        await UpdateCategories();
    }

    private async Task AddNewDishType()
    {
        var result = await DialogFactory.CreateAsync<DrinkCategoryCreatingDialog>();
        if (result?.Canceled == false && result.Data is DrinkCategoryCreatingDto newCategory)
        {
            await DrinkCategoryService.CreateAsync(newCategory);
            Snackbar.Add("Dish type added successfully!", Severity.Success);
            await UpdateCategories();
        }
    }

    private async Task EnableAsync(int id)
    {
        await DrinkCategoryService.EnableAsync(id);

        await UpdateCategories();
    }

    private async Task DisableAsync(int id)
    {
        await DrinkCategoryService.DisableAsync(id);

        await UpdateCategories();
    }

    private async Task EditItem(DrinkCategory model)
    {
        var dto = new EditDrinkCategoryDto()
        {
            Name = model.Name,
            IsShared = model.IsShared
        };

        var parameters = new DialogParameters<EditDrinkCategoryDialog>
            {
                { x => x.DrinkCategory, dto},
            };

        var result = await DialogFactory.CreateAsync<EditDrinkCategoryDialog>(parameters);

        if (result?.Canceled == false && result.Data is EditDrinkCategoryDto drinkCategory)
        {
            await DrinkCategoryService.UpdateAsync(model.Id, drinkCategory);
            Snackbar.Add("Успішно змінено!", Severity.Success);
            await UpdateCategories();
        }
        else
        {
            Snackbar.Add("Відмінено!", Severity.Warning);
        }
    }

    public async Task UpdateCategories()
    {
        DrinkCategories = await DrinkCategoryService.GetAllAsync(true);
        StateHasChanged();
    }
    private async Task DeleteItem(DrinkCategory category)
    {
        var result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await DrinkCategoryService.RemoveAsync(category.Id);
            Snackbar.Add("Deleted!", Severity.Warning);
            await UpdateCategories();
        }
    }
}