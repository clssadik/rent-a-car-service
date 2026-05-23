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

    public IActionResult Cars(int? editId)
    {
        return View(CreateAdminCarsViewModel(editId));
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

        var car = CreateCarFromForm(viewModel.Form);

        if (viewModel.Form.Id > 0)
        {
            var updated = _sampleDataService.UpdateCar(car);
            TempData["SuccessMessage"] = updated ? "Car updated successfully." : "Car could not be found.";
        }
        else
        {
            _sampleDataService.AddCar(car);
            TempData["SuccessMessage"] = "Car added successfully.";
        }

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

    private AdminCarsViewModel CreateAdminCarsViewModel(int? editId = null)
    {
        var viewModel = new AdminCarsViewModel
        {
            Cars = _sampleDataService.GetCars()
        };

        if (editId.HasValue)
        {
            var car = _sampleDataService.GetCarById(editId.Value);

            if (car != null)
            {
                viewModel.Form = new AdminCarFormViewModel
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Year = car.Year,
                    FuelType = car.FuelType,
                    Transmission = car.Transmission,
                    Type = car.Type,
                    SeatCount = car.SeatCount,
                    DailyPrice = car.DailyPrice,
                    ImageUrl = car.ImageUrl,
                    IsAvailable = car.IsAvailable
                };
            }
        }

        return viewModel;
    }

    private static Car CreateCarFromForm(AdminCarFormViewModel form)
    {
        return new Car
        {
            Id = form.Id,
            Brand = form.Brand,
            Model = form.Model,
            Year = form.Year,
            FuelType = form.FuelType,
            Transmission = form.Transmission,
            Type = form.Type,
            SeatCount = form.SeatCount,
            DailyPrice = form.DailyPrice,
            ImageUrl = form.ImageUrl,
            IsAvailable = form.IsAvailable,
            Description = $"{form.Brand} {form.Model} is available in the sample fleet."
        };
    }
}
