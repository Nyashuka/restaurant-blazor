using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Components.Authorization;

namespace RestaurantApp.Presentation.Services;

public static class AuthenticationStateExtensions
{
    public static string? GetUserId(this AuthenticationState authenticationState)
    {
        var user = authenticationState.User;
        return user.Claims
            .FirstOrDefault(
                claim => claim.Properties.Any(
                    prop => prop.Value == JwtRegisteredClaimNames.Sub
                )
            )?.Value;
    }
}