using Microsoft.AspNetCore.Mvc;
using RentACarService.Models;
using RentACarService.ViewModels;

namespace RentACarService.Controllers;

public class ReservationsController : Controller
{
    public IActionResult Create(int carId = 1)
    {
        var selectedCar = new Car
        {
            Id = carId,
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2022,
            FuelType = "Gasoline",
            Transmission = "Automatic",
            DailyPrice = 45
        };

        var reservation = new ReservationCreateViewModel
        {
            SelectedCar = selectedCar,
            RentalDays = 3
        };

        return View(reservation);
    }
}
