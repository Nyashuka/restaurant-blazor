using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Dtos.Editing;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Persistence.Interfaces;

namespace RestaurantApp.Application.Services;

public class EventTypeService : IEventTypeService
{
    private readonly IEventTypeRepository _eventTypeRepository;

    public EventTypeService(IEventTypeRepository eventTypeRepository)
    {
        _eventTypeRepository = eventTypeRepository;
    }

    public async Task CreateAsync(CreateEventTypeDto createEventTypeDto)
    {
        var model = new EventType(0, createEventTypeDto.Name);

        await _eventTypeRepository.AddAsync(model);
    }

    public async Task<List<EventType>> GetAllAsync()
    {
        return await _eventTypeRepository.GetAllAsync();
    }

    public async Task UpdateAsync(EditEventTypeDto eventTypeDto)
    {
        if (await _eventTypeRepository.GetByIdAsync(eventTypeDto.Id) is EventType eventType)
        {
            eventType.Update(eventTypeDto.Name);

            await _eventTypeRepository.UpdateAsync(eventType);
        }
    }

    public async Task RemoveAsync(int id)
    {
        if(await _eventTypeRepository.GetByIdAsync(id) is EventType eventType)
            await _eventTypeRepository.RemoveAsync(eventType);
    }
}
