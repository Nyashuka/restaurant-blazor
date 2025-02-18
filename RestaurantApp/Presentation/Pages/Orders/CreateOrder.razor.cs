using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dtos;
using RestaurantApp.Presentation.Dialogs;
using MudBlazor;

namespace RestaurantApp.Presentation.Pages.Orders;

public partial class CreateOrder
{
    private OrderInfoDto BaseInfo { get; set; } = new();
    private MenuForDate? CurrentMenuForDate { get; set; }

    private List<EventType> EventTypes { get; set; } = [];
    private List<Dish> FilteredDishes { get; set; } = [];
    private List<Menu> MenuVariants { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        EventTypes = await EventTypeService.GetAllAsync();
        SidebarStateService.OnCategorySelected += LoadDishesByCategory;
        FilteredDishes = await DishService.GetAllAsync();
        MenuVariants = await MenuService.GetAllAsync();
    }

    private async Task LoadDishesByCategory(int categoryId)
    {
        FilteredDishes = await DishService.GetByCategoryAsync(categoryId);
        StateHasChanged();
    }

    public async Task CreateOrderAsync()
    {

    }

    private async Task CalculateQuantity()
    {
        Dictionary<int, List<SelectedDishDto>> categorizedDishes = [];

        if(CurrentMenuForDate == null)
            return;

        foreach (var selectedDish in CurrentMenuForDate.SelectedDishes)
        {
            if(selectedDish.Dish is not null)
            {
                if(categorizedDishes.TryGetValue(selectedDish.Dish.DishCategoryId, out var dishes))
                {
                    dishes.Add(selectedDish);
                }
                else
                {
                    categorizedDishes.TryAdd(selectedDish.Dish.DishCategoryId, [ selectedDish ]);
                }
            }
        }

        foreach (var categorizedDish in categorizedDishes)
        {
            int count = categorizedDishes.Values.Count;
            int countPerDishForCategory = BaseInfo.GuestCount / count;
            int remainder = BaseInfo.GuestCount % count;
            bool isShared = false;

            foreach (var item in categorizedDish.Value)
            {
                if(item.Dish == null || item.Dish.DishCategory == null)
                    continue;

                isShared = item.Dish.DishCategory.IsShared;

                if(isShared)
                {
                    int neededWeight = item.Dish.RecommendedWeightPerPortion * countPerDishForCategory;

                    item.Count = (neededWeight / item.Dish.Weight) + (neededWeight % item.Dish.Weight);
                }
                else
                {
                    item.Count = countPerDishForCategory;
                }
            }

            var firstDishInCategory = categorizedDish.Value.FirstOrDefault();
            if (firstDishInCategory == null || firstDishInCategory.Dish == null)
                continue;

            if(isShared)
            {
                firstDishInCategory.Count +=
                    firstDishInCategory.Dish.RecommendedWeightPerPortion * remainder / firstDishInCategory.Dish.Weight;
            }
            else
            {
                firstDishInCategory.Count += remainder;
            }
        }

        StateHasChanged();
    }

    

    private async Task OnUseMenuClicked(int menuId)
    {
        var parameters = new DialogParameters<SelectDateToChangeDishes>
        {
            { x => x.MenusForDate, BaseInfo.MenusForDate },
        };

        var result = await DialogFactory.CreateAsync<SelectDateToChangeDishes>(parameters);

        if (result?.Canceled == true)
        {
            return;
        }

        if(result?.Data is MenuForDate menu)
        {
            Snackbar.Add("Selected something!", Severity.Warning);
            FilteredDishes = await DishService.GetAllAsync();

            var menuItems = await MenuService.GetMenuItemsByMenuId(menuId);
            menu.SelectedDishes = [];
            foreach(var item in menuItems)
            {
                menu.SelectedDishes.Add(
                    new SelectedDishDto(
                        await DishService.GetByIdAsync(item.DishId),
                        1
                    )
                );
            }

            StateHasChanged();
        }
    }

    private void AddDate()
    {
        if(BaseInfo.MenusForDate.Count >= 4)
            return;

        BaseInfo.MenusForDate.Add(new MenuForDate(null));
        StateHasChanged();
    }

    private readonly List<DateTime> _disabledDates =
    [
        new (2024, 12, 5),
        new (2024, 12, 10)
    ];

    public async Task<IEnumerable<EventType>> SearchEventType(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return EventTypes;

        return EventTypes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task<IEnumerable<MenuForDate>> SearchSelectedDishesDates(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        return BaseInfo.MenusForDate;
    }
}