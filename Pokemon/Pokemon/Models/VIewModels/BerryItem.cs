using PokeApiNet;

namespace Pokemon.Models.ViewModels;

public class BerryItem
{
    internal BerryItem(Item item)
    {
        Id = item.Id;
        Name = item.Name;
        Cost = item.Cost;
        Sprite = item.Sprites.Default;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public string Sprite { get; set; }
}