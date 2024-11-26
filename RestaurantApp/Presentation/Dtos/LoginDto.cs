using RestaurantApp.Core.Domain.Attributes;

namespace RestaurantApp.Presentation.Dtos;

public class LoginDto
{
    [ValidateEmailAddress]
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}