using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IEventTypeService
{
    Task<List<EventType>> GetAllAsync();
}