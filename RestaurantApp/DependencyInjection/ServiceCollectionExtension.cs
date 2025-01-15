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
using RestaurantApp.Presentation.Factories;
using RestaurantApp.Presentation.Services;
using RestaurantApp.Domain.Models;

namespace RestaurantApp.DependencyInjection;

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
        services.AddScoped<RestaurantDialogFactory>();


        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserSessionService, UserSessionService>();
        services.AddScoped<IEventTypeService, EventTypeService>();
        services.AddScoped<IDishTypeService, DishTypeService>();
        services.AddScoped<IDishService, DishService>();

        services.AddScoped<AuthenticationStateProvider, UserAuthenticationStateProvider>();

        services.AddSingleton<SidebarStateService>();

        return services;
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services
    )
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IEventTypeRepository, EventTypeRepository>();

        services.AddScoped<IDishTypeRepository, DishTypeRepository>();
        services.AddScoped<IDishIngredientRepository, DishIngredientRepository>();
        services.AddScoped<IDishRepository, DishRepository>();

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