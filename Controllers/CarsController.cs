using Microsoft.AspNetCore.Mvc;
using RentACarService.Services;
using RentACarService.ViewModels;

namespace RentACarService.Controllers;

public class CarsController : Controller
{
    private readonly SampleDataService _sampleDataService;

    public CarsController(SampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public IActionResult Index(string? brand, string? type, string? carType, string? transmission, string? priceRange)
    {
        var selectedType = string.IsNullOrWhiteSpace(type) ? carType : type;
        var cars = _sampleDataService.GetFilteredCars(brand, selectedType, transmission, priceRange);
        var viewModel = new CarsIndexViewModel
        {
            Cars = cars,
            Brand = brand,
            Type = selectedType,
            Transmission = transmission,
            PriceRange = priceRange
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
}
