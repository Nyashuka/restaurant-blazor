using MudBlazor;

using RestaurantApp.Application.Dtos;
using RestaurantApp.Domain.Models;
using RestaurantApp.Presentation.Dialogs;

namespace RestaurantApp.Presentation.Pages.Chief.Events;

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
            Snackbar.Add("Deleted!", Severity.Warning);
            _eventTypes = await EventTypeService.GetAllAsync();
            StateHasChanged();
        }
    }
}