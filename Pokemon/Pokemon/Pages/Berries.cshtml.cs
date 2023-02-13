using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemon.Services;

namespace Pokemon.Pages;

public class BerriesModel : PageModel
{
    private readonly BerriesService _service;

    public BerriesModel(BerriesService service)
    {
        _service = service;
    }
    public void OnGet()
    {
        
    }
}