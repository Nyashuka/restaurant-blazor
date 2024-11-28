namespace RestaurantApp.Infrastructure.Authentication;

public interface IJwtTokenGenerator
{
    string Generate(int id, string role);
}