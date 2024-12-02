
using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;

using RestaurantApp.Application.Interfaces;
using RestaurantApp.Application.Services;
using RestaurantApp.Infrastructure.Authentication;
using RestaurantApp.Infrastructure.Persistence.Constants;
using RestaurantApp.Infrastructure.Persistence.DbContexts;
using RestaurantApp.Infrastructure.Persistence.Interfaces;
using RestaurantApp.Infrastructure.Persistence.Repositories;
using RestaurantApp.Presentation.Interfaces;
using RestaurantApp.Presentation.Services;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddLibraries(
        this IServiceCollection services
    )
    {
        services.AddMudServices();
        services.AddBlazoredLocalStorage();

        return services;
    }

    public static IServiceCollection AddServices(
        this IServiceCollection services
    )
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserSessionService, UserSessionService>();
        services.AddScoped<AuthenticationStateProvider, UserAuthenticationStateProvider>();

        return services;
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services
    )
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddDatabaseService(
        this IServiceCollection services
    )
    {
        services.AddDbContextFactory<RestaurantDbContext>(options =>
            options.UseNpgsql(DbSettings.ConnectionString));

        services.AddScoped<RestaurantDbContext>(provider =>
        provider.GetRequiredService<IDbContextFactory<RestaurantDbContext>>().CreateDbContext());


        return services;
    }
}