using Microsoft.AspNetCore.Components.Authorization;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Domain.Services;
using RestaurantApp.Presentation.Dtos;

namespace RestaurantApp.Presentation.Services;

public class OrderPageService
{
    private Order? _currentOrder = null;

    public const int MIN_GUEST_COUNT = 35;
    public const int MAX_GUEST_COUNT = 125;
    public CreateOrderInfo OrderInfo { get; set; } = new();
    public OrderDayDto CurrentOrderDay { get; set; }
    public bool BaseInfoIsCorrect { get; private set; } = false;

    private readonly IDishService _dishService;
    private readonly IDrinkService _drinkService;
    private readonly IOrderService _orderService;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public event Action DataUpdated;

    public OrderPageService(IOrderService orderService, AuthenticationStateProvider authenticationStateProvider, IDishService dishService, IDrinkService drinkService)
    {
        _orderService = orderService;
        _authenticationStateProvider = authenticationStateProvider;
        _dishService = dishService;
        _drinkService = drinkService;

        OrderInfo.PropertyChanged += OnOrderInfoPropertyChanged;
        OrderInfo.GuestCount = MIN_GUEST_COUNT;
        CurrentOrderDay = new OrderDayDto(null);
        OrderInfo.AddDay(CurrentOrderDay);
    }

    public void InitializeOrderForEdit(Order order)
    {
        _currentOrder = order;
        OrderInfo.GuestCount = order.PeopleCount;

        OrderInfo.Reset();
        OrderInfo.EventType = order.EventType;

        foreach (var orderDay in order.OrderDays)
        {
            var orderDayDto = new OrderDayDto(orderDay.Date);
            orderDayDto.SetSelectedFoods(orderDay.OrderMenuItems.ToList());
            OrderInfo.AddDay(orderDayDto);
        }

        CurrentOrderDay = OrderInfo.OrderDays.First();

        OnOrderInfoPropertyChanged();
    }

    public double GetOrderPrice()
    {
        double price = 0;
        foreach(var orderDay in OrderInfo.OrderDays)
        {
            foreach(var selectedFoodItem in orderDay.SelectedFoodItems)
            {
                price += selectedFoodItem.Count * selectedFoodItem.Item.PricePerUnit;
            }
        }

        return price;
    }

    private void OnOrderInfoPropertyChanged()
    {
        BaseInfoIsCorrect = OrderInfo.EventType != null &&
            OrderInfo.GuestCount >= MIN_GUEST_COUNT &&
            OrderInfo.GuestCount <= MAX_GUEST_COUNT &&
            OrderInfo.OrderDays.Any(x => x.Date != null);
    }

    public async Task AddItem(FoodItem foodItem)
    {
        CurrentOrderDay?.AddFoodItem(foodItem, 1);
    }

    public void RemoveItem(FoodItem foodItem)
    {
        CurrentOrderDay?.RemoveFoodItemById(foodItem.Id);

        DataUpdated?.Invoke();
    }

    public async Task<List<FoodItem>> GetFoodItemsByCategory(CategoryBase category)
    {
        return category switch
        {
            DishCategory => (await _dishService.GetByCategoryAsync(category.Id)).Cast<FoodItem>().ToList(),
            DrinkCategory => (await _drinkService.GetByCategoryAsync(category.Id)).Cast<FoodItem>().ToList(),
            _ => throw new NotImplementedException(),
        };
    }

    public List<MenuItemToSelect> GenerateMenuItemsToSelect(
        List<FoodItem> foodItems,
        List<SelectedFoodItem> selectedFoodItems)
    {
        return foodItems.ConvertAll(item =>
            new MenuItemToSelect(selectedFoodItems.Any(x => x.Item.Id == item.Id) , item));
}

    public bool CheckSuccessStatus()
    {
        return OrderInfo.EventType != null &&
                OrderInfo.OrderDays.SingleOrDefault(x => x.Date != null) != null &&
                OrderInfo.GuestCount >= MIN_GUEST_COUNT;
    }

    public DateTime GetMinDate()
    {
        return DateTime.Now.AddDays(3);
    }

    public DateTime GetMaxDate()
    {
        return DateTime.Now.AddMonths(3);
    }

    public async Task RecalculateQuantity()
    {
        if(CurrentOrderDay == null)
            return;

        var dishes = CurrentOrderDay.SelectedFoodItems.Where(x => x.Item is Dish).ToList();
        var drinks = CurrentOrderDay.SelectedFoodItems.Where(x => x.Item is Drink).ToList();

        var dishesCalculator = new DishesQuantityCalculator();
        var drinksCalculator = new DrinksQuantityCalculator();

        await dishesCalculator.CalculateQuantity(OrderInfo.GuestCount, dishes);
        await drinksCalculator.CalculateQuantity(OrderInfo.GuestCount, drinks);
    }

    public async Task CreateOrderAsync()
    {
        var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        if(authenticationState == null || authenticationState?.User == null)
            return;

        string? userIdString = authenticationState.GetUserId();
        if (string.IsNullOrEmpty(userIdString))
            return;
        
        int userId = Convert.ToInt32(userIdString);

        if (_currentOrder == null)
        {
            await _orderService.CreateOrderAsync(userId, OrderInfo);
        }
        else
        {
            if (_currentOrder.UserId == userId)
            {
                await _orderService.UpdateOrderAsync(userId, _currentOrder.Id, OrderInfo);
                _currentOrder = null;
            }
        }
    }

    public void AddDate()
    {
        var lastOrderDay = OrderInfo.OrderDays.Last().Date;

        if(lastOrderDay == null)
            return;

        var orderDay = new OrderDayDto(((DateTime)lastOrderDay).AddDays(1));

        OrderInfo.AddDay(orderDay);

        DataUpdated?.Invoke();
    }

    public bool CanAddDay()
    {
        return OrderInfo.OrderDays.Count > 0 &&
            OrderInfo.OrderDays.Any(x => x.Date != null) &&
            OrderInfo.OrderDays.Count < 2;
    }

    public async Task<List<DateTime>> GetBookedDates()
    {
        return await _orderService.GetBookedDays();
    }

    public void Dispose()
    {
        _currentOrder = null;
    }
}