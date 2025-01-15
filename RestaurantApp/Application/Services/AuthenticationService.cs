
using RestaurantApp.Application.Dtos;
using RestaurantApp.Application.Errors;
using RestaurantApp.Application.Interfaces;
using RestaurantApp.Domain.Constants;
using RestaurantApp.Domain.Enums;
using RestaurantApp.Domain.Models;
using RestaurantApp.Infrastructure.Authentication;
using RestaurantApp.Infrastructure.Persistence.Interfaces;
using RestaurantApp.Infrastructure.Security;

namespace RestaurantApp.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);

        if(user == null)
        {
            return AuthenticationResult.Failure(ErrorMessages.InvalidEmailOrPassword);
        }

        if(!PasswordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
            return AuthenticationResult.Failure(ErrorMessages.InvalidEmailOrPassword);
        }

        return AuthenticationResult.Success(_jwtTokenGenerator.Generate(
            user.Id,
            RoleStorage.GetRoleName(user.Role)
        ));
    }

    public async Task<AuthenticationResult> RegisterAsync(string firstName, string lastName, string email, string password)
    {
        if((await _userRepository.GetUserByEmailAsync(email)) is User)
        {
            return AuthenticationResult.Failure(ErrorMessages.EmailAlreadyTaken);
        }

        PasswordHasher.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

        User user = new User(RoleEnum.User, firstName, lastName, email, passwordHash, passwordSalt);
        await _userRepository.AddAsync(user);

        return AuthenticationResult.Success(_jwtTokenGenerator.Generate(
            user.Id,
            RoleStorage.GetRoleName(user.Role)
        ));
    }
}
