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
        Hp = pokemon.Stats.FirstOrDefault(stat => stat.Stat.Name == "hp")?.BaseStat ?? -1;
        Attack = pokemon.Stats.FirstOrDefault(stat => stat.Stat.Name == "attack")?.BaseStat ?? -1;
        Defense = pokemon.Stats.FirstOrDefault(stat => stat.Stat.Name == "defense")?.BaseStat ?? -1;
        Speed = pokemon.Stats.FirstOrDefault(stat => stat.Stat.Name == "speed")?.BaseStat ?? -1;
    }

    public int Id { get; }
    public string Name { get; }
    public int Hp { get; }
    public int Attack { get; }
    public int Defense { get; }
    public int Speed { get; }
    public string GifSprite { get; }


    public string OfficialArt { get; }
}