namespace RestaurantApp.Domain.Models;

public class Menu
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int EventTypeId { get; private set; }
    public EventType? EventType { get; private set; }
    public List<MenuItem>? MenuItems { get; private set; }

    public Menu(int id, string name, int eventTypeId, EventType? eventType, List<MenuItem>? menuItems)
    {
        Id = id;
        Name = name;
        EventTypeId = eventTypeId;
        EventType = eventType;
        MenuItems = menuItems;
    }

    private Menu() {}
}