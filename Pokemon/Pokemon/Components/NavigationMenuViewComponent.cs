using Microsoft.AspNetCore.Mvc;
using Pokemon.Services;

namespace Pokemon.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly LocationsService _service;

    public NavigationMenuViewComponent(LocationsService service)
    {
        _service = service;
    }


    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.SelectedRegion = RouteData.Values["region"]!;
        var regions = (await _service.GetRegions()).ToList();
        return View(regions);
    }
}