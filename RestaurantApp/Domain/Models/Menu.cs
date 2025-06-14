
namespace RestaurantApp.Domain.Models;

public class Menu
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int EventTypeId { get; private set; }
    public EventType? EventType { get; private set; }
    public string ImageUrl { get; private set; } = string.Empty;
    public List<MenuItem>? MenuItems { get; private set; }

    public Menu(string name, int eventTypeId, string imageUrl)
    {
        Name = name;
        EventTypeId = eventTypeId;
        ImageUrl = imageUrl;
    }

    private Menu() {}

    internal void Update(string name, int eventTypeId, string imageUrl)
    {
        Name = name;
        EventTypeId = eventTypeId;
        ImageUrl = imageUrl;
    }
}