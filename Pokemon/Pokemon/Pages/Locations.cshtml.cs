using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemon.Services;

namespace Pokemon.Pages;

public class LocationsModel : PageModel
{
    private readonly LocationsService _service;

    public LocationsModel(LocationsService service)
    {
        _service = service;
    }

    public IEnumerable<string> Locations { get; set; } = Enumerable.Empty<string>();

    public async Task OnGet()
    {
        var region = RouteData.Values["region"]?.ToString();
        if (region != null)
        {
            // region selected, get region locations
            Locations = await _service.GetLocations(region);
        }
        else
        {
            // no region, get all locations
        }
    }
}