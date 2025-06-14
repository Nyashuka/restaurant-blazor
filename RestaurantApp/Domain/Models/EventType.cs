namespace RestaurantApp.Domain.Models;

public class EventType
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    public EventType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void Update(string name)
    {
        Name = name;
    }
}