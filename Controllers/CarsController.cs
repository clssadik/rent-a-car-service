using Microsoft.AspNetCore.Mvc;
using RentACarService.Services;
using RentACarService.ViewModels;
using System.IO;

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
        var viewModel = new CarsIndexViewModel
        {
            Cars = cars
        };

        return View(viewModel);
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

    public IActionResult Review(int id = 1)
    {
        var car = _sampleDataService.GetCarById(id);

        if (car == null)
        {
            return NotFound();
        }

        var prefix = $"{car.Brand}-{car.Model}".ToLower().Replace(" ", "-");
        var dir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "cars", prefix);
        var images = new List<string>();
        if (Directory.Exists(dir))
        {
            var files = Directory.GetFiles(dir, "*")
                .Select(Path.GetFileName)
                .OrderBy(f => f)
                .ToList();
            foreach (var f in files)
                images.Add($"/images/cars/{prefix}/{f}");
        }
        ViewBag.Images = images;

        return View(car);
    }
}
