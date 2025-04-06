
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Assortment;

public partial class AssortmentPage
{
    public List<FoodItem> FoodItems { get; set; } = [];
    private bool DrawerOpen { get; set; } = true;

    protected override async Task OnInitializedAsync()
    {
        FoodItems = (await DishService.GetAllAsync()).ConvertAll(d => (FoodItem)d);
        FoodItems.AddRange((await DrinkService.GetAllAsync()).ConvertAll(d => (FoodItem)d));
        SidebarStateService.OnCategorySelected += LoadFoodItemsByCategory;
    }

    private async Task LoadFoodItemsByCategory(CategoryBase category)
    {
        FoodItems.Clear();

        FoodItems = category switch
        {
            DishCategory => (await DishService.GetByCategoryAsync(category.Id)).Cast<FoodItem>().ToList(),
            DrinkCategory => (await DrinkService.GetByCategoryAsync(category.Id)).Cast<FoodItem>().ToList(),
            _ => [],
        };

        await InvokeAsync(StateHasChanged);
    }
}