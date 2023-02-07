using PokeApiNet;

namespace Pokemon.Services;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddWebServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<PokeApiClient>();
        
        return serviceCollection;
    }
}