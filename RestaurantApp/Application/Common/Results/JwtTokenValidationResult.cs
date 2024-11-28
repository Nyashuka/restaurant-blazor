using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace RestaurantApp.Application.Common.Results;

public class JwtTokenValidationResult
{
    public ClaimsPrincipal? Principal { get; }
    public string? Error { get; }

    private JwtTokenValidationResult(ClaimsPrincipal? principal, string? error)
    {
        Principal = principal;
        Error = error;
    }

    public static JwtTokenValidationResult Success(ClaimsPrincipal principal) => new JwtTokenValidationResult(principal, null);

    public static JwtTokenValidationResult Failure(string error) => new JwtTokenValidationResult(null, error);
}