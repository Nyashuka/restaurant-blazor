namespace RestaurantApp.Infrastructure.Authentication;

public interface IJwtTokenGenerator
{
    string Create(int id, string role);
}