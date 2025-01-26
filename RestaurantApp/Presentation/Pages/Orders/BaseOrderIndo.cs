using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Orders;

public class BaseOrderInfo
{
    public bool IsSuccess { get; private set; }
    public int GuestCount { get; set; } = 10;

    private DateTime? _selectedDate;
    public DateTime? SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value;
            UpdateStatus();
        }
    }

    private EventType? _selectedEventType;
    public EventType? SelectedEventType
    {
        get => _selectedEventType;
        set
        {
            _selectedEventType = value;
            UpdateStatus();
        }
    }

    private void UpdateStatus()
    {
        IsSuccess = CheckSuccessStatus();
    }

    public bool CheckSuccessStatus()
    {
        return SelectedEventType != null && SelectedDate != null;
    }
}