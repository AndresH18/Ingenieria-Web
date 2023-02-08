using Microsoft.AspNetCore.Mvc;

namespace Pokemon.Components;

public class NavigationMenuViewComponent : ViewComponent
{

    public IViewComponentResult Invoke()
    {
        return View();
    }
}