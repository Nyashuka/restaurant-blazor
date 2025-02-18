using MudBlazor;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.Subcategories;

public partial class SubcategoriesPage
{
    private List<DishSubcategory> DishSubcategories { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        DishSubcategories = await DishSubcategoryService.GetAllAsync();
    }

    private async Task AddNewDishType()
    {
        var result = await DialogFactory.CreateAsync<CreateSubcategoryDialog>();
        if (result?.Canceled == false && result.Data is CreateDishSubcategoryDto newDishType)
        {
            await DishSubcategoryService.CreateAsync(newDishType);
            Snackbar.Add("Dish type added successfully!", Severity.Success);
            DishSubcategories = await DishSubcategoryService.GetAllAsync();
            StateHasChanged();
        }
    }

    private async Task DeleteItem(DishSubcategory dishSubcategory)
    {
        var result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await DishSubcategoryService.RemoveAsync(dishSubcategory.Id);
            Snackbar.Add("Deleted!", Severity.Warning);
            DishSubcategories = await DishSubcategoryService.GetAllAsync();
            StateHasChanged();
        }
    }
}