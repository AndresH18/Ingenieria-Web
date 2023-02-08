using Microsoft.AspNetCore.Mvc;
using PokemonModel = PokeApiNet.Pokemon;

namespace Pokemon.Controllers;

// [Route("Home2")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View(new PokemonModel {Name = "Lucario"});
    }
}