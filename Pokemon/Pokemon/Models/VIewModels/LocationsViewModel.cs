namespace Pokemon.Models.ViewModels;

public class LocationsViewModel
{
    public string Region { get; init; } = string.Empty;
    public IEnumerable<string> Locations { get; init; } = Enumerable.Empty<string>();
    public PageInfo PageInfo { get; init; } = new();
}