using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemon.Models.ViewModels;
using Pokemon.Services;

namespace Pokemon.Pages;

public class PokemonInfoModel : PageModel
{
    private readonly PokemonService _service;
    private readonly ILogger<PokemonInfoModel> _logger;

    public PokemonInfoModel(PokemonService service, ILogger<PokemonInfoModel> logger)
    {
        _service = service;
        _logger = logger;
    }

    //
    // [BindProperty(SupportsGet = true)] public int Id { get; set; }
    public PokemonData? Data { get; private set; }

    public async Task<IActionResult> OnGet(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return RedirectToPage("/Error");

        _logger.LogDebug("Getting pokemon: name={name}", name);


        return Page();
    }
}