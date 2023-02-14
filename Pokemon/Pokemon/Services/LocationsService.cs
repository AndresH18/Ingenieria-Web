using System.Net;
using PokeApiNet;
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

    public async Task<LocationsViewModel?> GetLocations(int pageSize, int pageOffset)
    {
        if (pageSize <= 0 || pageOffset < 0)
            return null;

        try
        {
            var locationPage = await _client.GetNamedResourcePageAsync<Location>(pageSize, pageOffset);
            var locations = locationPage
                .Results
                .Select(l => l.Name)
                .Order()
                .Skip(pageSize * pageOffset)
                .Take(pageSize);

            return new LocationsViewModel
            {
                Locations = locations.ToList(),
                PageInfo = new PageInfo
                {
                    TotalItems = locationPage.Count,
                    ItemsPerPage = pageSize,
                    CurrentPage = pageOffset + 1,
                }
            };
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
                return null;
            _logger.LogError(e, "Error while getting locations. pageSize={pageSize}, pageOffset={pageOffset}", pageSize,
                pageOffset);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Unexpected error while getting locations. pageSize={pageSize}, pageOffset={pageOffset}", pageSize,
                pageOffset);
            throw;
        }
    }

    public async Task<LocationsViewModel?> GetLocations(string region, int pageSize, int pageOffset)
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

            return new LocationsViewModel
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

    public async Task<LocationsViewModel?> GetLocations(string region)
    {
        return await GetLocations(region, 10, 0);
    }
}