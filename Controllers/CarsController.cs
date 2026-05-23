using Microsoft.AspNetCore.Mvc;
using RentACarService.Services;

namespace RentACarService.Controllers;

public class CarsController : Controller
{
    private readonly SampleDataService _sampleDataService;

    public CarsController(SampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public IActionResult Index()
    {
        var cars = _sampleDataService.GetCars();

        return View(cars);
    }

    public IActionResult Details(int id = 1)
    {
        var car = _sampleDataService.GetCarById(id);

        if (car == null)
        {
            return NotFound();
        }

        return View(car);
    }
}
