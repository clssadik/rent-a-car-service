using Microsoft.AspNetCore.Mvc;

namespace RentACarService.Controllers;

public class ReservationsController : Controller
{
    public IActionResult Create()
    {
        return View();
    }
}
