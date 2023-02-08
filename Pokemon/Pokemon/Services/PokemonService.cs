using System.Collections.Generic;
using Poke = PokeApiNet;


namespace Pokemon.Services;

public class PokemonService : IPokemonService
{
    private readonly Poke::PokeApiClient _client;
    private int _total;


    public PokemonService(Poke::PokeApiClient client)
    {
        _client = client;
        _client.GetNamedResourcePageAsync<Poke::Pokemon>().ContinueWith((result) => { _total = result.Result.Count; });
    }

    public async Task<IEnumerable<string>> GetAllAsync(int offset = 0)
    {
        var pokemonList = (await _client.GetNamedResourcePageAsync<Poke::Pokemon>(100, offset)).Results;

        return pokemonList.Select(p => p.Name).ToList();
    }
}