using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
