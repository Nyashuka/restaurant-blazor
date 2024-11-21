
using MudBlazor.Services;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddLibraries(
        this IServiceCollection services
    )
    {
        services.AddMudServices();

        return services;
    }
}