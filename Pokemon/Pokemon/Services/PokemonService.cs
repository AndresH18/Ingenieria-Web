using System.Net;
using Pokemon.Models.ViewModels;
using Poke = PokeApiNet;


namespace Pokemon.Services;

public class PokemonService
{
    private readonly Poke::PokeApiClient _client;

    // private readonly ParallelOptions _parallelOptions;
    private int _total;

    public PokemonService(Poke::PokeApiClient client)
    {
        _client = client;
        _client.GetNamedResourcePageAsync<Poke::Pokemon>().ContinueWith(result => { _total = result.Result.Count; });
        // _parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 3 };
    }

    public int ItemsPerPage { get; set; } = 10;

    public int TotalPages => (int)Math.Ceiling((decimal)_total / ItemsPerPage);

    public async Task<PokemonListViewModel> GetPageAsync(int pageOffset = 0)
    {
        var page = await _client.GetNamedResourcePageAsync<Poke::Pokemon>(ItemsPerPage, pageOffset * ItemsPerPage);

        var pokemonList = from p in await _client.GetResourceAsync(page.Results)
            select new PokemonData(p);

        return new PokemonListViewModel
        {
            Pokemon = pokemonList.ToList(), PageInfo = new PageInfo
            {
                CurrentPage = pageOffset,
                ItemsPerPage = ItemsPerPage,
                TotalItems = _total
            }
        };
    }

    public async Task<PokemonData?> Get(int id)
    {
        if (id <= 0)
            return default;

        Poke::Pokemon? pokemon;
        try
        {
            pokemon = await _client.GetResourceAsync<Poke::Pokemon>(id);
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
                return default;

            throw;
        }

        return pokemon == null! ? default : new PokemonData(pokemon);
    }

    public async Task<PokemonData?> Get(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return default;

        Poke::Pokemon? pokemon;
        try
        {
            pokemon = await _client.GetResourceAsync<Poke::Pokemon>(name);
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode == HttpStatusCode.NotFound)
                return default;
            throw;
        }

        return pokemon == null! ? default : new PokemonData(pokemon);
    }
}