using System.Net;
using PokeApiNet;
using Pokemon.Models.ViewModels;

namespace Pokemon.Services;

public class BerriesService
{
    private readonly PokeApiClient _client;
    private readonly ILogger<BerriesService> _logger;

    private int _totalItems;

    public BerriesService(PokeApiClient client, ILogger<BerriesService> logger)
    {
        _client = client;
        _logger = logger;
        _client.GetNamedResourcePageAsync<Berry>().ContinueWith(r => _totalItems = r.Result.Count);
    }

    public async Task<IEnumerable<BerryItem>> GetAll()
    {
        try
        {
            var berriesPage = await _client.GetNamedResourcePageAsync<Berry>(_totalItems, 0);
            var berriesList = await _client.GetResourceAsync(berriesPage.Results);
            var itemsList = await _client.GetResourceAsync(berriesList.Select(b => b.Item).ToList());

            var items = itemsList.Select(item => new BerryItem(item)).ToList();

            return items;
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
                return Enumerable.Empty<BerryItem>();
            _logger.LogError(ex, "Error while getting berries");
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Unexpected error.");
            throw;
        }
    }

    public async Task<NamedApiResourceList<Berry>?> Get()
    {
        try
        {
            var berriesResourceList = await _client.GetNamedResourcePageAsync<Berry>(_totalItems, 0);
            return berriesResourceList;
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
                return null;
            _logger.LogError(ex, "Error while getting berries");
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Unexpected error.");
            throw;
        }
    }

    public async Task<BerryData?> Get(string berryName)
    {
        if (string.IsNullOrWhiteSpace(berryName))
            return null;
        try
        {
            var berry = await _client.GetResourceAsync<Berry>(berryName);
            var item = await _client.GetResourceAsync(berry.Item);

            return new BerryData(berry, item);
        }
        catch (HttpRequestException e)
        {
            if (e.StatusCode == HttpStatusCode.NotFound)
                return null;
            _logger.LogError(e, "Error while getting information for: {berryName}", berryName);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Unexpected error.");
            throw;
        }
    }
}