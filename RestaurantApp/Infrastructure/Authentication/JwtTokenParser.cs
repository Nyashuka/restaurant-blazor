using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.IdentityModel.Tokens;

using RestaurantApp.Application.Common.Results;

namespace RestaurantApp.Infrastructure.Authentication;

public class JwtTokenParser
{
    public static JwtTokenValidationResult ValidateToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            return JwtTokenValidationResult.Failure("Token can't be empty!");
        }

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            JwtTokenSettings.JwtKey
        ));

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            ClaimsPrincipal principal = tokenHandler.ValidateToken(
                token, tokenValidationParameters, out SecurityToken validatedToken);

            return JwtTokenValidationResult.Success(principal);
        }
        catch (SecurityTokenExpiredException)
        {
            return JwtTokenValidationResult.Failure("Token is expired. Login again, please!");
        }
        catch (Exception e)
        {
            return JwtTokenValidationResult.Failure($"Unknown error: {e.Message}");
        }
    }
}