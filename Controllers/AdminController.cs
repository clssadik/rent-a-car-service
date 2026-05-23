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
        return View(CreateAdminCarsViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cars(AdminCarsViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Cars = _sampleDataService.GetCars();

            return View(viewModel);
        }

        TempData["SuccessMessage"] = "Car saved successfully.";

        return RedirectToAction(nameof(Cars));
    }

    private AdminCarsViewModel CreateAdminCarsViewModel()
    {
        return new AdminCarsViewModel
        {
            Cars = _sampleDataService.GetCars()
        };
    }
}
