using System.Security.Claims;

using Microsoft.AspNetCore.Components.Authorization;

using RestaurantApp.Infrastructure.Authentication;
using RestaurantApp.Presentation.Interfaces;

namespace RestaurantApp.Presentation.Services;

public class UserAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IUserSessionService _userSessionService;
    private readonly ClaimsPrincipal _anonymousPrincipals = new ClaimsPrincipal(new ClaimsIdentity());

    public UserAuthenticationStateProvider(IUserSessionService userSessionService)
    {
        _userSessionService = userSessionService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var jwtToken = await _userSessionService.GetTokenAsync();

        if(string.IsNullOrEmpty(jwtToken))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var tokenValidationResult = JwtTokenParser.ValidateToken(jwtToken);

        if(tokenValidationResult.Principal == null)
        {
            return new AuthenticationState(_anonymousPrincipals);
        }

        var authState = new AuthenticationState(tokenValidationResult.Principal);

        NotifyAuthenticationStateChanged(Task.FromResult(authState));

        return authState;
    }
}