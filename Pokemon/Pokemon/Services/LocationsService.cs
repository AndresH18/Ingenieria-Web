using PokeApiNet;

namespace Pokemon.Services;

public class LocationsService
{
    private readonly PokeApiClient _client;
    private readonly ILogger<LocationsService> _logger;

    public LocationsService(PokeApiClient client, ILogger<LocationsService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<IEnumerable<string>> GetRegions()
    {
        try
        {
            var regions = await _client.GetNamedResourcePageAsync<Region>();
            return regions.Results.Select(r => r.Name).ToList();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Unexpected error while getting Regions");
            throw;
        }
    }
}