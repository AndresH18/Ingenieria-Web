// See https://aka.ms/new-console-template for more information

using PokeApiNet;

Console.WriteLine("Hello, World!");

var client = new PokeApiClient();
var pokemon = await client.GetResourceAsync<Pokemon>("lucario");
Console.WriteLine(pokemon.Name);
Console.WriteLine("Default sprite: {0}", pokemon.Sprites.Other.OfficialArtwork.FrontDefault);

var species = await client.GetResourceAsync(pokemon.Species);

Console.WriteLine(
    $"The '{species.Name}' sprite-url: {pokemon.Sprites.FrontDefault}'\n" +
    $"Is legendary: {species.IsLegendary}\n" +
    $"Is Mythical: {species.IsMythical}");