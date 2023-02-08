using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Controllers
{
    public class BerriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
