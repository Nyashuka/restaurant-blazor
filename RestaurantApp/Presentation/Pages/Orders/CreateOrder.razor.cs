using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dtos;
using RestaurantApp.Presentation.Dialogs;
using MudBlazor;
using RestaurantApp.Presentation.Services;
using RestaurantApp.Presentation.Pages.Constants;
using RestaurantApp.Domain.Services;

namespace RestaurantApp.Presentation.Pages.Orders;

public partial class CreateOrder : IDisposable
{
    private OrderInfoDto BaseInfo { get; set; } = new();
    private MenuForDate? CurrentMenuForDate { get; set; }

    private List<EventType> EventTypes { get; set; } = [];
    private List<MenuItemToSelect> MenuItemsToSelect { get; set; } = [];
    private List<Menu> MenuVariants { get; set; } = [];

    public int DaysCount => BaseInfo.MenusForDate.Count(x => x.Date != null);

    private bool DrawerOpen { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        EventTypes = await EventTypeService.GetAllAsync();
        SidebarStateService.OnCategorySelected += LoadFoodItemsByCategory;
        MenuVariants = await MenuService.GetAllAsync();

        CurrentMenuForDate = BaseInfo.MenusForDate.FirstOrDefault();
    }

    private async Task LoadFoodItemsByCategory(CategoryBase category)
    {
        MenuItemsToSelect.Clear();

        List<FoodItem> items = category switch
        {
            DishCategory => (await DishService.GetByCategoryAsync(category.Id)).Cast<FoodItem>().ToList(),
            DrinkCategory => (await DrinkService.GetByCategoryAsync(category.Id)).Cast<FoodItem>().ToList(),
        };

        MenuItemsToSelect.AddRange(items.Select(item =>
            new MenuItemToSelect(CurrentMenuForDate?.SelectedFoodItems.Any(x => x.Item.Id == item.Id) ?? false, item)));

        await InvokeAsync(StateHasChanged);
    }

    public async Task CreateOrderAsync()
    {
        var authenticationState = await AuthStateProvider.GetAuthenticationStateAsync();
        if(authenticationState == null || authenticationState?.User == null)
            return;

        string? userIdString = authenticationState.GetUserId();
        if (string.IsNullOrEmpty(userIdString))
            return;

        await OrderService.CreateOrderAsync(Convert.ToInt32(userIdString), BaseInfo);

        NavigationManager.NavigateTo(NavigationManager.BaseUri + Urls.OrdersUrl, true);
    }

    private async Task CalculateQuantity()
    {
        if(CurrentMenuForDate == null)
            return;

        var dishes = CurrentMenuForDate.SelectedFoodItems.Where(x => x.Item is Dish).ToList();
        var drinks = CurrentMenuForDate.SelectedFoodItems.Where(x => x.Item is Drink).ToList();

        var dishesCalculator = new DishesQuantityCalculator();
        var drinksCalculator = new DrinksQuantityCalculator();

        var calculatedItems = new List<SelectedFoodItem>();
        calculatedItems.AddRange(await dishesCalculator.CalculateQuantity(BaseInfo.GuestCount, dishes));
        calculatedItems.AddRange(await drinksCalculator.CalculateQuantity(BaseInfo.GuestCount, drinks));

        StateHasChanged();
    }

    private void OnAddItem(FoodItem foodItem)
    {
        CurrentMenuForDate?.AddFoodItem(new SelectedFoodItem(foodItem, 1));
    }

    private void OnRemoveItem(FoodItem foodItem)
    {
        CurrentMenuForDate?.RemoveFoodItem(foodItem.Id);
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

            var menuItems = await MenuService.GetMenuItemsByMenuId(menuId);
            menu.SelectedFoodItems = [];
            foreach(var item in menuItems)
            {
                menu.SelectedFoodItems.Add(
                    new SelectedFoodItem(
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
        if(BaseInfo.MenusForDate.Count >= 2)
            return;

        DateTime? nextDate = BaseInfo.MenusForDate.Last().Date;
        if(nextDate == null)
        {
            return;
        }

        nextDate = ((DateTime)nextDate).Date.AddDays(1);
        BaseInfo.MenusForDate.Add(new MenuForDate(nextDate));
        StateHasChanged();
    }

    private void OnActivePanelIndexChanged(int id)
    {
        DrawerOpen = id == 2;
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

        return BaseInfo.MenusForDate.Where(x => x.Date != null);
    }

    void IDisposable.Dispose()
    {
        SidebarStateService.IsSidebarVisible = false;
    }
}