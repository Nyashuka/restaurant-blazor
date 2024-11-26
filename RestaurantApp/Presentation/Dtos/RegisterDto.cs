using System.ComponentModel.DataAnnotations;
using RestaurantApp.Core.Domain.Attributes;

namespace RestaurantApp.Presentation.Dtos;

public class RegisterDto
{
    [MaxLength(8)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(8)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [ValidateEmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(30, ErrorMessage = "Password must be at least 4 characters long.", MinimumLength = 4)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;
}