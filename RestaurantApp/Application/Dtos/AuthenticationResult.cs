namespace RestaurantApp.Application.Dtos;

public class AuthenticationResult
{
    public bool IsSuccess { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;

    public AuthenticationResult(bool isSuccess, string accessToken, string errorMessage)
    {
        IsSuccess = isSuccess;
        AccessToken = accessToken;
        ErrorMessage = errorMessage;
    }
}