using Microsoft.AspNetCore.Mvc;
using RentACarService.Models;
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

        var car = new Car
        {
            Brand = viewModel.Form.Brand,
            Model = viewModel.Form.Model,
            Year = viewModel.Form.Year,
            FuelType = viewModel.Form.FuelType,
            Transmission = viewModel.Form.Transmission,
            Type = viewModel.Form.Type,
            SeatCount = viewModel.Form.SeatCount,
            DailyPrice = viewModel.Form.DailyPrice,
            ImageUrl = viewModel.Form.ImageUrl,
            IsAvailable = viewModel.Form.IsAvailable,
            Description = $"{viewModel.Form.Brand} {viewModel.Form.Model} is available in the sample fleet."
        };

        _sampleDataService.AddCar(car);
        TempData["SuccessMessage"] = "Car added successfully.";

        return RedirectToAction(nameof(Cars));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCar(int id)
    {
        var deleted = _sampleDataService.DeleteCar(id);
        TempData["SuccessMessage"] = deleted ? "Car deleted successfully." : "Car could not be found.";

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
