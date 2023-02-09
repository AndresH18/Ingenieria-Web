namespace Pokemon.Models.ViewModels;

public class PokemonListViewModel
{
    public List<PokemonData> Pokemon { get; set; } = new();
}

public class PokemonData
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string GifSprite { get; set; } = string.Empty;
}