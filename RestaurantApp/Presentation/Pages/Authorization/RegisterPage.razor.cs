using RestaurantApp.Presentation.Dtos;

namespace RestaurantApp.Presentation.Pages.Authorization;

public partial class RegisterPage
{
    private RegisterDto RegisterDto { get; set; } = new ();

    public async Task OnValidSubmit()
    {
        var result = await _authenticationService.RegisterAsync(
            RegisterDto.FirstName,
            RegisterDto.LastName,
            RegisterDto.Email,
            RegisterDto.Password
        );

        if (result.IsSuccess)
        {
            await _userSessionService.SaveTokenAsync(result.AccessToken);
            await _authStateProvider.GetAuthenticationStateAsync();

            _navigationManager.NavigateTo("/", true);
        }
    }
}