
using Blazored.LocalStorage;

using RestaurantApp.Presentation.Constants;
using RestaurantApp.Presentation.Dtos;
using RestaurantApp.Presentation.Interfaces;

namespace RestaurantApp.Presentation.Services;

public class UserSessionService : IUserSessionService
{
    private readonly ILocalStorageService _localStorageService;

    public UserSessionService(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<string?> GetTokenAsync()
    {
        return await _localStorageService.GetItemAsync<string>(LocalStorageKeys.AccessToken);
    }

    public async Task SaveTokenAsync(string token)
    {
        await _localStorageService.SetItemAsync(LocalStorageKeys.AccessToken, token);
    }

    public async Task RemoveTokenAsync()
    {
        await _localStorageService.RemoveItemAsync(LocalStorageKeys.AccessToken);
    }
}