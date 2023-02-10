using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pokemon.Models.ViewModels;
using Pokemon.Services;

namespace Pokemon.Pages
{
    public class PokemonModel : PageModel
    {
        private readonly PokemonService _service;

        public PokemonModel(PokemonService service)
        {
            _service = service;
        }

        public PokemonListViewModel? PokemonViewModel { get; set; }

        public async Task OnGet()
        {
            PokemonViewModel = await _service.GetPageAsync();
        }
    }
}