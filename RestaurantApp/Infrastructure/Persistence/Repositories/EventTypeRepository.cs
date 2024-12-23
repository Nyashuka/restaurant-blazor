using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Infrastructure.Persistence.Repositories;

public class EventTypeRepository : IEventTypeRepository
{
    private readonly List<EventType> _eventTypes = new List<EventType>()
    {
        new EventType(1, "Marriage"),
        new EventType(2, "Birthday")
    };

    public Task AddAsync(EventType eventType)
    {
        throw new NotImplementedException();
    }

    public async Task<List<EventType>> GetAllAsync()
    {
        return await Task.FromResult(_eventTypes);
    }

    public Task RemoveAsync(EventType eventType)
    {
        throw new NotImplementedException();
    }
}