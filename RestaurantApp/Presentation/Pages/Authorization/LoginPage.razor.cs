using RestaurantApp.Presentation.Dtos;

namespace RestaurantApp.Presentation.Pages.Authorization;

public partial class LoginPage
{
    private LoginDto LoginDto { get; set; } = new ();

    public async Task OnValidSubmit()
    {
        var result = await _authenticationService.LoginAsync(
            LoginDto.Email,
            LoginDto.Password
            );

        if (result.IsSuccess)
        {
            await _userSessionService.SaveTokenAsync(result.AccessToken);
            await _authStateProvider.GetAuthenticationStateAsync();
            
            _navigationManager.NavigateTo("/", true);
        }
    }
}