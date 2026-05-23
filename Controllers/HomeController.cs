using Microsoft.AspNetCore.Mvc;

namespace RentACarService.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
