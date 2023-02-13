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

var page = await client.GetNamedResourcePageAsync<Pokemon>(10, 0);
Console.WriteLine("Total results for pokemon page: {0}", page.Count);

var pokemonList = await client.GetResourceAsync(page.Results);

Console.WriteLine("Getting data using Page link");

pokemonList.ForEach(p =>
    Console.WriteLine($"name: {p.Name}, gif: {p.Sprites.Versions.GenerationV.BlackWhite.Animated.FrontDefault}"));


Console.WriteLine("BERRIES");
var berryItem = await client.GetResourceAsync<Item>(126);

Console.WriteLine($"""
Name: {berryItem.Name}
Cost: {berryItem.Cost}
Description: {string.Join("\n\t", berryItem.FlavorGroupTextEntries.Where(f => f.Language.Name == "en").Select(f => f.Text))}
""");