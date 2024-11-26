
using Blazored.LocalStorage;
using MudBlazor.Services;

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

        return services;
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services
    )
    {

        return services;
    }

    public static IServiceCollection AddDatabaseService(
        this IServiceCollection services
    )
    {
        // services.AddScoped<CarJournalDbContext>(provider =>
        // provider.GetRequiredService<IDbContextFactory<CarJournalDbContext>>().CreateDbContext());


        return services;
    }
}