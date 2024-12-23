using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Orders;

public partial class CreateOrder
{
    bool _expandedBaseInfo = true;
    bool _expandedMenu = false;

    private void ToggleSection(ref bool sectionToToggle, ref bool otherSection)
    {
        if (!sectionToToggle)
        {
            otherSection = false;
        }

        sectionToToggle = !sectionToToggle;
    }

    private void OnExpandCollapseBaseInfoClick()
    {
        ToggleSection(ref _expandedBaseInfo, ref _expandedMenu);
    }

    private void OnExpandCollapseMenuClick()
    {
        ToggleSection(ref _expandedMenu, ref _expandedBaseInfo);
    }


    private int _stage = 0;

    private int GuestCount { get; set; } = 10;

    private DateTime? _selectedDate;
    private DateTime? SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value;
            _stage = 2;

            StateHasChanged();
        }
    }

    private EventType? _selectedEventType;
    private EventType? SelectedEventType
    {
        get => _selectedEventType;
        set
        {
            _selectedEventType = value;
            _stage = 1;

            StateHasChanged();
        }
    }

    private void ToggleCategories()
    {
        _sidebarStateService.IsSidebarVisible = !_sidebarStateService.IsSidebarVisible;
    }

    private List<EventType> EventTypes = new();

    protected override async Task OnInitializedAsync()
    {
        EventTypes = await _eventTypeService.GetAllAsync();
    }

    private readonly List<DateTime> _disabledDates = new List<DateTime>
    {
        new DateTime(2024, 12, 5),
        new DateTime(2024, 12, 10)
    };

    public async Task<IEnumerable<EventType>> SearchEventType(string value, CancellationToken token)
    {
        await Task.Delay(5, token);

        if (string.IsNullOrEmpty(value))
            return EventTypes;

        return EventTypes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase));
    }
}