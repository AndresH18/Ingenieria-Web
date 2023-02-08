using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers;

public class GamesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}