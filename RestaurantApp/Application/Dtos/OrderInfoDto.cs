using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dtos;

namespace RestaurantApp.Application.Dtos;

public class OrderInfoDto
{
    private const int MIN_GUEST_COUNT = 35;
    public bool IsSuccess { get; private set; }

    private int _guestCount = MIN_GUEST_COUNT;
    public int GuestCount
    {
        get => _guestCount;
        set
        {
            _guestCount = value;
            UpdateStatus();
        }
    }

    public List<MenuForDate> MenusForDate { get; set; } = [];

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

    public OrderInfoDto()
    {
        var menu = new MenuForDate(null);
        menu.DateChanged += UpdateStatus;

        MenusForDate = new List<MenuForDate>()
        {
            menu
        };
    }

    private void UpdateStatus()
    {
        IsSuccess = CheckSuccessStatus();
    }

    public bool CheckSuccessStatus()
    {
        return SelectedEventType != null && MenusForDate.SingleOrDefault(x => x.Date != null) != null && GuestCount >= MIN_GUEST_COUNT;
    }
}