using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dtos;

namespace RestaurantApp.Application.Dtos;

public class OrderInfoDto
{
    public bool IsSuccess { get; private set; }
    public int GuestCount { get; set; } = 10;
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

    private void UpdateStatus()
    {
        IsSuccess = CheckSuccessStatus();
    }

    public bool CheckSuccessStatus()
    {
        return SelectedEventType != null;
    }
}