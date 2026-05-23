using Microsoft.AspNetCore.Mvc;
using RentACarService.Models;
using RentACarService.ViewModels;

namespace RentACarService.Controllers;

public class ReservationsController : Controller
{
    public IActionResult Create(int carId = 1)
    {
        var reservation = new ReservationCreateViewModel
        {
            SelectedCar = GetSelectedCar(carId),
            SelectedCarId = carId,
            RentalDays = 3
        };

        return View(reservation);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ReservationCreateViewModel reservation)
    {
        reservation.SelectedCar = GetSelectedCar(reservation.SelectedCarId);
        reservation.RentalDays = CalculateRentalDays(reservation.PickupDate, reservation.ReturnDate);

        if (reservation.PickupDate.HasValue &&
            reservation.ReturnDate.HasValue &&
            reservation.ReturnDate <= reservation.PickupDate)
        {
            ModelState.AddModelError(nameof(reservation.ReturnDate), "Return date must be after pickup date.");
        }

        if (!ModelState.IsValid)
        {
            return View(reservation);
        }

        TempData["SuccessMessage"] = "Reservation created successfully.";

        return RedirectToAction(nameof(Create), new { carId = reservation.SelectedCarId });
    }

    private static Car GetSelectedCar(int carId)
    {
        return new Car
        {
            Id = carId,
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2022,
            FuelType = "Gasoline",
            Transmission = "Automatic",
            DailyPrice = 45
        };
    }

    private static int CalculateRentalDays(DateTime? pickupDate, DateTime? returnDate)
    {
        if (!pickupDate.HasValue || !returnDate.HasValue || returnDate <= pickupDate)
        {
            return 3;
        }

        return (returnDate.Value.Date - pickupDate.Value.Date).Days;
    }
}
