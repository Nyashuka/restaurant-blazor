using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RestaurantApp.Core.Domain.Attributes;

public class ValidateEmailAddressAttribute : ValidationAttribute
{
    private const string EmailPattern = @"^[\w\.\-]+@([\w\-]+\.)+[a-zA-Z]{2,}$";

    public ValidateEmailAddressAttribute()
    {
        ErrorMessage = "Please, enter the correct email address!";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (value is string email && Regex.IsMatch(email, EmailPattern))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage);
    }
}