using Microsoft.AspNetCore.Mvc;
using RentACarService.Models;

namespace RentACarService.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var featuredCars = new List<Car>
        {
            new() { Id = 1, Brand = "Toyota", Model = "Corolla", Type = "Sedan", DailyPrice = 45 },
            new() { Id = 2, Brand = "Volkswagen", Model = "Golf", Type = "Hatchback", DailyPrice = 50 },
            new() { Id = 3, Brand = "Hyundai", Model = "Tucson", Type = "SUV", DailyPrice = 75 }
        };

        return View(featuredCars);
    }
}
