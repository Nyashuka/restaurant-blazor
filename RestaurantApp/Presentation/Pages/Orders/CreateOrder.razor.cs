using RestaurantApp.Domain.Models;

namespace RestaurantApp.Presentation.Pages.Orders;

public partial class CreateOrder
{
    private BaseOrderInfo BaseInfo { get; set; } = new();


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