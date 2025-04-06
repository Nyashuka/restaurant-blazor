using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dtos;
using RestaurantApp.Presentation.Dialogs;
using MudBlazor;
using RestaurantApp.Presentation.Services;
using RestaurantApp.Presentation.Pages.Constants;

namespace RestaurantApp.Presentation.Pages.Orders;

public partial class CreateOrder : IDisposable
{
    // dto
    private CreateOrderInfo BaseInfo => OrderPageService.OrderInfo;

    // view
    private OrderDayDto? CurrentOrderDay => OrderPageService.CurrentOrderDay;
    private List<EventType> EventTypes { get; set; } = [];
    private List<MenuItemToSelect> MenuItemsToSelect { get; set; } = [];
    private List<Menu> MenuVariants { get; set; } = [];
    private bool DrawerOpen { get; set; } = false;

    public DateTime? MinDate { get; set; }

    protected override async Task OnInitializedAsync()
    {
        EventTypes = await EventTypeService.GetAllAsync();
        SidebarStateService.OnCategorySelected += LoadFoodItemsByCategory;
        MenuVariants = await MenuService.GetAllAsync();

        MinDate = OrderPageService.GetMinDate();
    }

    private async Task LoadFoodItemsByCategory(CategoryBase category)
    {
        MenuItemsToSelect.Clear();

        var foodItems = await OrderPageService.GetFoodItemsByCategory(category);

        MenuItemsToSelect = OrderPageService
            .GenerateMenuItemsToSelect(foodItems, OrderPageService.CurrentOrderDay?.SelectedFoodItems ?? []);

        await InvokeAsync(StateHasChanged);
    }

    public async Task CreateOrderAsync()
    {
        await OrderPageService.CreateOrderAsync();

        NavigationManager.NavigateTo(NavigationManager.BaseUri + Urls.OrdersUrl, true);
    }

    private async Task CalculateQuantity()
    {
        await OrderPageService.RecalculateQuantity();

        StateHasChanged();
    }

    private async Task OnUseMenuClicked(int menuId)
    {
        var parameters = new DialogParameters<OrderDaySelectionDialog>
        {
            { x => x.OrderDays, BaseInfo.OrderDays },
        };

        var result = await DialogFactory.CreateAsync<OrderDaySelectionDialog>(parameters);

        if (result?.Canceled == true)
        {
            return;
        }

        if(result?.Data is OrderDayDto orderDay)
        {
            Snackbar.Add("Selected something!", Severity.Warning);

            var menuItems = await MenuService.GetMenuItemsByMenuId(menuId);
            orderDay.SelectedFoodItems = [];
            foreach(var item in menuItems)
            {
                orderDay.SelectedFoodItems.Add(
                    new SelectedFoodItem(
                        await FoodItemService.GetByIdAsync<FoodItem>(item.FoodItemId),
                        1
                    )
                );
            }

            StateHasChanged();
        }
    }

    private void AddDate()
    {
        if(BaseInfo.OrderDays.Count >= 2)
            return;

        BaseInfo.AddDay(new OrderDayDto(null));
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

    public async Task<IEnumerable<OrderDayDto>> SearchSelectedDishesDates(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        return BaseInfo.OrderDays.Where(x => x.Date != null);
    }

    void IDisposable.Dispose()
    {
        SidebarStateService.IsSidebarVisible = false;
    }
}