namespace RestaurantApp.Application.Dtos;

public class AuthenticationResult
{
    public bool IsSuccess { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;

    private AuthenticationResult(bool isSuccess, string accessToken, string errorMessage)
    {
        IsSuccess = isSuccess;
        AccessToken = accessToken;
        ErrorMessage = errorMessage;
    }

    public static AuthenticationResult Success(string accessToken)
    {
        return new AuthenticationResult(true, accessToken, string.Empty);
    }

    public static AuthenticationResult Failure(string errorMessage)
    {
        return new AuthenticationResult(false, string.Empty, errorMessage);
    }
}