using MudBlazor;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.DishTypes;

public partial class DishCategoriesPage
{
    private List<DishCategory> _dishCategories = [];

    protected override async Task OnInitializedAsync()
    {
        _dishCategories = await DishCategoryService.GetAllAsync();
    }

    private async Task AddNewDishType()
    {
        var result = await DialogFactory.CreateAsync<CreateDishTypeDialog>();
        if (result?.Canceled == false && result.Data is CreateDishTypeDto newDishType)
        {
            await DishCategoryService.CreateAsync(newDishType);
            Snackbar.Add("Dish type added successfully!", Severity.Success);
            _dishCategories = await DishCategoryService.GetAllAsync();
            StateHasChanged();
        }
    }

    private async Task EnableAsync(int id)
    {
        await DishCategoryService.EnableAsync(id);

        await UpdateCategories();
    }

    private async Task DisableAsync(int id)
    {
        await DishCategoryService.DisableAsync(id);

        await UpdateCategories();
    }

    private async Task EditItem(DishCategory model)
    {
        var dto = new EditDishCategoryDto()
        {
            Name = model.Name,
            IsShared = model.IsShared
        };

        var parameters = new DialogParameters<EditDishCategoryDialog>
            {
                { x => x.Dish, dto},
            };

        var result = await DialogFactory.CreateAsync<EditDishCategoryDialog>(parameters);

        if (result?.Canceled == false && result.Data is EditDishCategoryDto dishType)
        {
            await DishCategoryService.UpdateAsync(model.Id, dishType);
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
        _dishCategories = await DishCategoryService.GetAllAsync();
        StateHasChanged();
    }

    private async Task DeleteItem(DishCategory dishType)
    {
        var result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await DishCategoryService.RemoveAsync(dishType.Id);
            Snackbar.Add("Deleted!", Severity.Warning);
            await UpdateCategories();
        }
    }
}