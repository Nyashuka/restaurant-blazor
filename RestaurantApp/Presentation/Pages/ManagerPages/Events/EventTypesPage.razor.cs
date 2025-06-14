using MudBlazor;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Dtos.Editing;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.ManagerPages.Events;

public partial class EventTypesPage
{
    private List<EventType> _eventTypes = [];

    protected override async Task OnInitializedAsync()
    {
        _eventTypes = await EventTypeService.GetAllAsync();
    }

    private async Task AddNewEventType()
    {
        DialogResult? result = await DialogFactory.CreateAsync<CreateEventTypesDialog>();

        if (result?.Canceled == false && result.Data is CreateEventTypeDto newEventType)
        {
            await EventTypeService.CreateAsync(newEventType);
            Snackbar.Add("Dish type added successfully!", Severity.Success);
            _eventTypes = await EventTypeService.GetAllAsync();
            StateHasChanged();
        }
    }

    private async Task DeleteItem(EventType eventType)
    {
        DialogResult? result = await DialogFactory.CreateAsync<DeleteItemDialog>();

        if (result?.Canceled == false)
        {
            await EventTypeService.RemoveAsync(eventType.Id);
            Snackbar.Add("Видалено!", Severity.Warning);
            await UpdateEventTypes();
        }
    }

    private async Task UpdateEventTypes()
    {
        _eventTypes = await EventTypeService.GetAllAsync();
        StateHasChanged();
    }

    private async Task EditAsync(EventType eventType)
    {
        var dto = new EditEventTypeDto()
        {
            Id = eventType.Id,
            Name = eventType.Name,
        };

        var parameters = new DialogParameters<EditEventTypeDialog>
        {
            {
                x => x.EventTypeDto, dto
            },
        };

        var result = await DialogFactory.CreateAsync<EditEventTypeDialog>(parameters);

        if (result?.Canceled == false && result.Data is EditEventTypeDto eventTypeResult)
        {
            await EventTypeService.UpdateAsync(eventTypeResult);
            Snackbar.Add("Успішно змінено!", Severity.Success);
            await UpdateEventTypes();
        }
        else
        {
            Snackbar.Add("Відмінено!", Severity.Warning);
        }
    }
}