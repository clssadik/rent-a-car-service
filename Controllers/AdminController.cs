using Microsoft.AspNetCore.Mvc;

namespace RentACarService.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Cars()
    {
        return View();
    }
}
