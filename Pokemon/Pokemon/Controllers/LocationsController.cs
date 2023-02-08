using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
