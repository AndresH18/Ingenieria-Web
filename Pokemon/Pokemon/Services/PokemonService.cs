using System.Collections.Generic;
using System.Linq;
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
        _client.GetNamedResourcePageAsync<Poke::Pokemon>().ContinueWith((result) => { _total = result.Result.Count; });
        // _parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 3 };
    }

    public int ItemsPerPage { get; set; } = 100;

    public async Task<PokemonListViewModel> GetPageAsync(int offset = 0)
    {
        var page = await _client.GetNamedResourcePageAsync<Poke::Pokemon>(ItemsPerPage, offset);

        var pokemonList = from p in (await _client.GetResourceAsync(page.Results))
            select new PokemonData
            {
                Id = p.Id, Name = p.Name,
                GifSprite = p.Sprites.Versions.GenerationV.BlackWhite.Animated.FrontDefault
            };

        return new PokemonListViewModel() { Pokemon = pokemonList.ToList() };
    }

    // public async Task<IEnumerable<string>> GetPageAsync(int offset = 0)
    // {
    //     var pokemonList = (await _client.GetNamedResourcePageAsync<Poke::Pokemon>(100, offset)).Results;
    //
    //     return pokemonList.Select(p => p.Name).ToList();
    // }
}