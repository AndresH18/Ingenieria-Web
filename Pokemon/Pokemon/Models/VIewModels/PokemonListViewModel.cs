namespace Pokemon.Models.ViewModels;

public class PokemonListViewModel
{
    public List<PokemonData> Pokemon { get; set; } = new();
    public PageInfo PageInfo { get; set; } = new();
}

public class PokemonData
{
    internal PokemonData(PokeApiNet.Pokemon pokemon)
    {
        Id = pokemon.Id;
        Name = pokemon.Name;
        GifSprite = pokemon.Sprites.Versions.GenerationV.BlackWhite.Animated.FrontDefault;
        OfficialArt = pokemon.Sprites.Other.OfficialArtwork.FrontDefault;
    }

    public int Id { get; }
    public string Name { get; }
    public string GifSprite { get; }

    public string OfficialArt { get; }
}