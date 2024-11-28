
using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Interfaces;

namespace RestaurantApp.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    public Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        throw new NotImplementedException();
    }
}
