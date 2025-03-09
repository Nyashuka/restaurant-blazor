using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dtos;
using RestaurantApp.Presentation.Dialogs;
using MudBlazor;
using RestaurantApp.Presentation.Services;
using RestaurantApp.Presentation.Pages.Constants;

namespace RestaurantApp.Presentation.Pages.Orders;

public partial class CreateOrder
{
    private OrderInfoDto BaseInfo { get; set; } = new();
    private MenuForDate? CurrentMenuForDate { get; set; }

    private List<EventType> EventTypes { get; set; } = [];
    private List<DishToSelect> FilteredDishes { get; set; } = [];
    private List<Menu> MenuVariants { get; set; } = [];

    public int DaysCount => BaseInfo.MenusForDate.Count(x => x.Date != null);

    protected override async Task OnInitializedAsync()
    {
        EventTypes = await EventTypeService.GetAllAsync();
        SidebarStateService.OnCategorySelected += LoadDishesByCategory;
        MenuVariants = await MenuService.GetAllAsync();
    }

    private async Task LoadDishesByCategory(int categoryId)
    {
        var dishes = await DishService.GetByCategoryAsync(categoryId);
        FilteredDishes = [];
        foreach(var dish in dishes)
        {
            bool isSelected = CurrentMenuForDate?.SelectedDishes.Any(x => x.Dish.Id == dish.Id) == true;

            FilteredDishes.Add(new DishToSelect(){
                IsSelected = isSelected,
                Dish = dish
            });
        }
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

    private async Task Calc(List<SelectedDishDto> dishes)
    {
        
    }

    private async Task CalculateQuantity()
    {
        // страви відгруповані по категоріям, щоб обрахувати кількість в межах категорії
        Dictionary<int, List<SelectedDishDto>> categorizedDishes = [];

        if(CurrentMenuForDate == null)
            return;

        // групуємо по категоріям обрані страви
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

        // основний цикл, проходиться по категоріям страв
        foreach (var categorizedDish in categorizedDishes)
        {
            // кількість категорій
            int categoryCount = categorizedDishes.Values.Count;
            // кількість страв на 1 категорію
            int countPerDishForCategory = BaseInfo.GuestCount / categoryCount;
            // залишок кількості
            int remainder = BaseInfo.GuestCount % categoryCount;
            bool isShared = false;

            // проходимося по кожній страві в вибраній категорії
            foreach (var item in categorizedDish.Value)
            {
                if(item.Dish == null || item.Dish.DishCategory == null)
                    continue;

                isShared = item.Dish.DishCategory.IsShared;

                if(isShared)
                {
                    // обрахувати скільки 
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

    private void OnAddDish(Dish dish)
    {
        CurrentMenuForDate?.AddDish(new SelectedDishDto(dish, 1));
    }

    private void OnRemoveDish(Dish dish)
    {
        CurrentMenuForDate?.RemoveDish(dish.Id);
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

        return BaseInfo.MenusForDate.Where(x => x.Date != null);
    }


    private DateRange _dateRange = new();
    private DateRange DateRange
    {
        get => _dateRange;
        set
        {
            _dateRange = value;
        }
    }
    private DateTime _minDate = DateTime.Now.Date;
    private DateTime _maxDate = DateTime.Now.Date.AddMonths(1);
    private const int _maxDays = 7; // Ліміт у 7 днів

    private async Task OnDateRangeChanged(DateRange newRange)
    {
        _dateRange = newRange;

        if (newRange.Start.HasValue)
        {
            // Додаємо в _disabledDates всі дати, які виходять за ліміт
            for (DateTime date = _minDate; date <= _maxDate; date = date.AddDays(1))
            {
                if (date < newRange.Start || date > newRange.Start.Value.AddDays(_maxDays - 1))
                {
                    _disabledDates.Add(date);
                }
            }
        }

        await InvokeAsync(StateHasChanged);
    }


    private string HelperText => $"Range: {_minDate:M} to {_maxDate:M}";
}