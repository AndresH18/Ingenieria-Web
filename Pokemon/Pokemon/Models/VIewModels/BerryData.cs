using PokeApiNet;

namespace Pokemon.Models.ViewModels;

public class BerryData
{
    internal BerryData(Berry berry, Item item)
    {
        BerryId = berry.Id;
        BerryName = berry.Name;
        ItemId = item.Id;
        ItemName = item.Name;
        ItemCost = item.Cost;
        Sprite = item.Sprites.Default;
    }

    public int BerryId { get; }
    public int ItemId { get; }
    public string BerryName { get; }
    public string ItemName { get; }
    public int ItemCost { get; }
    public string Sprite { get; }
}