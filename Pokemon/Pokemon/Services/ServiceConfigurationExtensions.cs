using PokeApiNet;

namespace Pokemon.Services;

public static class ServiceConfigurationExtensions
{
    public static IServiceCollection AddPokemonServices(this IServiceCollection services)
    {
        services.AddSingleton<PokeApiClient>();
        services.AddScoped<PokemonService>();
        services.AddScoped<BerriesService>();

        return services;
    }
}