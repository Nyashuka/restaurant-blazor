using RestaurantApp.Presentation.Dtos;

namespace RestaurantApp.Presentation.Interfaces;

public interface IUserSessionService
{
    Task<string?> GetTokenAsync();

    Task SaveTokenAsync(string token);

    Task RemoveTokenAsync();
}