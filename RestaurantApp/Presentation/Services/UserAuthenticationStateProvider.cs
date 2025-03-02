using System.Security.Claims;

using Microsoft.AspNetCore.Components.Authorization;

using RestaurantApp.Infrastructure.Authentication;
using RestaurantApp.Presentation.Interfaces;

namespace RestaurantApp.Presentation.Services;

public class UserAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IUserSessionService _userSessionService;
    private readonly ClaimsPrincipal _anonymousPrincipals = new(new ClaimsIdentity());

    public UserAuthenticationStateProvider(IUserSessionService userSessionService)
    {
        _userSessionService = userSessionService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var authState = new AuthenticationState(_anonymousPrincipals);
        var jwtToken = await _userSessionService.GetTokenAsync();

        if(!string.IsNullOrEmpty(jwtToken))
        {
            var tokenValidationResult = JwtTokenParser.ValidateToken(jwtToken);

            if (tokenValidationResult.Principal != null)
            {
                authState = new AuthenticationState(tokenValidationResult.Principal);
            }
        }

        NotifyAuthenticationStateChanged(Task.FromResult(authState));

        return authState;
    }
}