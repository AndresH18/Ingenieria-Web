// See https://aka.ms/new-console-template for more information

using PokeApiNet;


var client = new PokeApiClient();
var pokemon = await client.GetResourceAsync<Pokemon>("eevee");
Console.WriteLine("Pokemon: {0}", pokemon.Name);
Console.WriteLine("Default sprite: {0}", pokemon.Sprites.Other.OfficialArtwork.FrontDefault);

var species = await client.GetResourceAsync(pokemon.Species);

Console.WriteLine($"""
The '{species.Name}' sprite-url: {pokemon.Sprites.FrontDefault}'
Is legendary: {species.IsLegendary}
Is Mythical: {species.IsMythical}
""");
var evoChain = await client.GetResourceAsync(species.EvolutionChain);
Console.WriteLine($"--{evoChain.Chain.Species.Name} evolves to:");

evoChain.Chain.EvolvesTo.ForEach(EvolutionChainSpecies);

void EvolutionChainSpecies(ChainLink chainLink)
{
    Console.WriteLine("Name = {0}", chainLink.Species.Name);
    if (chainLink.EvolvesTo.Count != 0)
    {
        chainLink.EvolvesTo.ForEach(EvolutionChainSpecies);
    }
}

var page = await client.GetNamedResourcePageAsync<Pokemon>();
Console.WriteLine("Total results for pokemon page: {0}", page.Count);