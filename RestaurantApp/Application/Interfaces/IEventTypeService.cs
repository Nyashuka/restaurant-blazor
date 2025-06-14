using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Dtos.Editing;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.Application.Interfaces;

public interface IEventTypeService
{
    Task CreateAsync(CreateEventTypeDto createEventTypeDto);
    Task RemoveAsync(int id);
    Task<List<EventType>> GetAllAsync();
    Task UpdateAsync(EditEventTypeDto eventTypeDto);
}