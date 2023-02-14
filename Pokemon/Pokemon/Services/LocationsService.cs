using PokeApiNet;
using Pokemon.Models;

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

    public async Task<IEnumerable<string>> GetLocations(string region)
    {
        if (string.IsNullOrWhiteSpace(region))
            return Enumerable.Empty<string>();
        try
        {
            var regionResource = await _client.GetResourceAsync<Region>(region);

            return regionResource.Locations.Select(r => r.Name).Order().ToList();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Unexpected error while getting locations for {region}", region);
            throw;
        }
    }
}