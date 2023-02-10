namespace Pokemon.Models.ViewModels;

public class PokemonListViewModel
{
    public List<PokemonData> Pokemon { get; set; } = new();
}

public class PokemonData
{
    public PokemonData()
    {
        
    }

    internal PokemonData(PokeApiNet.Pokemon pokemon)
    {
        Id = pokemon.Id;
        Name = pokemon.Name;
        GifSprite = pokemon.Sprites.Versions.GenerationV.BlackWhite.Animated.FrontDefault;
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string GifSprite { get; set; } = string.Empty;
}