using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Dtos;

public class CreateOrderInfo
{
    private EventType? _eventType;
    private int _guestCount;

    public event Action PropertyChanged;

    public EventType? EventType
    {
        get { return _eventType; }
        set
        {
            _eventType = value;
            OnPropertyChanged();
        }
    }
    public int GuestCount
    {
        get { return _guestCount; }
        set
        {
            _guestCount = value;
            OnPropertyChanged();
        }
    }

    private List<OrderDayDto> _orderDays = new();
    public IReadOnlyList<OrderDayDto> OrderDays => _orderDays;

    public void AddDay(OrderDayDto orderDay)
    {
        orderDay.DateChanged += OnPropertyChanged;
        _orderDays.Add(orderDay);
    }

    private void OnPropertyChanged()
    {
        PropertyChanged?.Invoke();
    }
}