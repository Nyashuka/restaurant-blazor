using RestaurantApp.Application.Dtos;

namespace RestaurantApp.Application.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password);
    Task<AuthenticationResult> LoginAsync(string email, string password);
}