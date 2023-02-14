using System.Net;
using PokeApiNet;
using Pokemon.Models;
using Pokemon.Models.ViewModels;

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
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
                return Enumerable.Empty<string>();
            _logger.LogError(ex, "Error while getting regions");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Unexpected error while getting Regions");
            throw;
        }
    }

    [Obsolete]
    public async Task<IEnumerable<string>> GetLocation(string region, int pageSize = 10, int pageOffset = 0)
    {
        if (string.IsNullOrWhiteSpace(region) || pageSize <= 0 || pageOffset < 0)
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

    public async Task<LocationsViewModel?> GetLocations(string region, int pageSize = 10, int pageOffset = 0)
    {
        if (string.IsNullOrWhiteSpace(region) || pageSize <= 0 || pageOffset < 0)
            return null;
        try
        {
            var regionResource = await _client.GetResourceAsync<Region>(region);

            var locations = regionResource
                .Locations
                .Select(r => r.Name)
                .Order()
                .Skip(pageOffset * pageSize)
                .Take(pageSize);

            return new LocationsViewModel()
            {
                Region = region,
                PageInfo = new PageInfo
                {
                    TotalItems = regionResource.Locations.Count,
                    ItemsPerPage = pageSize,
                    CurrentPage = pageOffset + 1
                },
                Locations = locations.ToList()
            };
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
                return null;
            _logger.LogError(ex, "Error while getting region locations");
            throw;
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "Unexpected error while getting locations for {region}", region);
            throw;
        }
    }
}