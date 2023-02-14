using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemon.Models.ViewModels;
using Pokemon.Services;

namespace Pokemon.Pages;

public class LocationsModel : PageModel
{
    private readonly LocationsService _service;

    public LocationsModel(LocationsService service)
    {
        _service = service;
    }

    public LocationsViewModel LocationsViewModel { get; set; } = new();

    public int CurrentPage => LocationsViewModel.PageInfo.CurrentPage;
    public int TotalPages => LocationsViewModel.PageInfo.TotalPages;

    public IEnumerable<string> Locations => LocationsViewModel.Locations;


    public async Task OnGet(int pageNumber, int size)
    {
        pageNumber = pageNumber >= 1 ? pageNumber - 1 : 0;
        size = size >= 1 ? size : 10;

        var region = RouteData.Values["region"]?.ToString();
        if (region != null)
        {
            // region selected, get region locations
            LocationsViewModel = await _service.GetLocations(region, size, pageNumber) ?? new LocationsViewModel();
            // CurrentPage = LocationsViewModel.PageInfo.CurrentPage;
            // TotalPages = (int) Math.Ceiling(Locations.Count() / (double) _pageSize);
        }
        else
        {
            // no region, get all locations
        }
    }

    public async Task OnGetPrevious()
    {
        await OnGet(CurrentPage - 1, LocationsViewModel.PageInfo.ItemsPerPage);
    }

    public async Task OnGetNext()
    {
        await OnGet(CurrentPage + 1, LocationsViewModel.PageInfo.ItemsPerPage);
    }
    public async Task OnGetPage(int pageNumber)
    {
        await OnGet(pageNumber, LocationsViewModel.PageInfo.ItemsPerPage);
    }
}