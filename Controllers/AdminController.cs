using Microsoft.AspNetCore.Mvc;
using RentACarService.Services;
using RentACarService.ViewModels;

namespace RentACarService.Controllers;

public class AdminController : Controller
{
    private readonly SampleDataService _sampleDataService;

    public AdminController(SampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public IActionResult Index()
    {
        var cars = _sampleDataService.GetCars();
        var recentReservations = _sampleDataService.GetRecentReservations();

        var dashboard = new AdminDashboardViewModel
        {
            TotalCars = cars.Count,
            ActiveReservations = 8,
            Customers = 56,
            TotalRevenue = 4820,
            RecentReservations = recentReservations
        };

        return View(dashboard);
    }

    public IActionResult Cars()
    {
        var cars = _sampleDataService.GetCars();

        return View(cars);
    }
}
