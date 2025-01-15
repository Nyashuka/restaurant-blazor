using Microsoft.AspNetCore.Components;

using MudBlazor;

namespace RestaurantApp.Presentation.Factories;

public class RestaurantDialogFactory(IDialogService dialogService)
{
    private IDialogService DialogService { get; } = dialogService;

    public async Task<DialogResult?> CreateAsync<T>() where T : ComponentBase
    {
        var parameters = new DialogParameters { };
        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };

        var dialog = await DialogService.ShowAsync<T>("", parameters, options);

        return await dialog.Result;
    }
}