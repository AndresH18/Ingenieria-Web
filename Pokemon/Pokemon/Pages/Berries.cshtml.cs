using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemon.Models.ViewModels;
using Pokemon.Services;

namespace Pokemon.Pages;

public class BerriesModel : PageModel
{
    private readonly BerriesService _service;

    public BerriesModel(BerriesService service)
    {
        _service = service;
    }

    public List<BerryItem> Berries { get; set; } = new();

    public async Task OnGet()
    {
        Berries = (await _service.GetAll()).ToList();
    }
}