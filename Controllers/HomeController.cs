using Microsoft.AspNetCore.Mvc;
using RentACarService.Services;

namespace RentACarService.Controllers;

public class HomeController : Controller
{
    private readonly SampleDataService _sampleDataService;

    public HomeController(SampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public IActionResult Index()
    {
        var featuredCars = _sampleDataService.GetFeaturedCars();

        return View(featuredCars);
    }

}
