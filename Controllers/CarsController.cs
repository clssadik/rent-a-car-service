using Microsoft.AspNetCore.Mvc;

namespace RentACarService.Controllers;

public class CarsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details()
    {
        return View();
    }
}
