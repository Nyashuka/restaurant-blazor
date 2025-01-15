using RestaurantApp.Domain.Models;

namespace RestaurantApp.Infrastructure.Persistence.Interfaces;

public interface IEventTypeRepository
{
    Task AddAsync(EventType eventType);
    Task RemoveAsync(EventType eventType);
    Task<List<EventType>> GetAllAsync();
    Task<EventType?> GetByIdAsync(int id);
}