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

        [BindProperty(SupportsGet = true)] public int Id { get; set; }

        public PokemonListViewModel? PokemonViewModel { get; set; }
        public int? CurrentPage => PokemonViewModel?.PageInfo.CurrentPage;
        public int? TotalPages => PokemonViewModel?.PageInfo.TotalPages - 1;

        public async Task OnGet()
        {
            if (Id > 0)
            {
                PokemonViewModel = await _service.GetPageAsync(Id - 1);
            }
        }

        public bool IsPageSelected(int index)
        {
            return index switch
            {
                0 => CurrentPage == 0,
                1 => CurrentPage != 0 && CurrentPage != TotalPages,
                2 => CurrentPage == TotalPages,
                _ => false
            };
        }

        public string GetPageUrl(int? page)
        {
            if (page >= 0 && TotalPages >= page)
            {
                return Url.Action("", new { Id = page }) ?? string.Empty;
            }

            return "";
        }

        public string? GetPageNumber(int offset)
        {
            if (CurrentPage == 0)
            {
                switch (offset)
                {
                    case -1:
                        return (CurrentPage + 1).ToString();
                    case 0:
                        return (CurrentPage + 2).ToString();
                    case 1:
                        return (CurrentPage + 3).ToString();
                }
            }
            else if (CurrentPage == TotalPages)
            {
                switch (offset)
                {
                    case 1:
                        return (CurrentPage + 1).ToString();
                    case 0:
                        return (CurrentPage + 2).ToString();
                    case -1:
                        return (CurrentPage + 3).ToString();
                }
            }
            else
            {
                switch (offset)
                {
                    case 1:
                        return (CurrentPage + 2).ToString();
                    case 0:
                        return (CurrentPage + 1).ToString();
                    case -1:
                        return CurrentPage.ToString();
                }
            }

            return string.Empty;
        }
    }
}