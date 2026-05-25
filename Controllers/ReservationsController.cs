using Microsoft.AspNetCore.Mvc;
using RentACarService.Models;
using RentACarService.Services;
using RentACarService.ViewModels;

namespace RentACarService.Controllers;

public class ReservationsController : Controller
{
    private readonly SampleDataService _sampleDataService;

    public ReservationsController(SampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public IActionResult Create(int carId = 1)
    {
        TempData.Remove("SuccessMessage");
        var reservation = new ReservationCreateViewModel
        {
            SelectedCar = GetSelectedCar(carId),
            SelectedCarId = carId,
            RentalDays = 3,
            Provinces = _sampleDataService.GetProvinces()
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
            ModelState.AddModelError(nameof(reservation.ReturnDate), "İade tarihi alış tarihinden sonra olmalıdır.");
        }

        if (!_sampleDataService.IsCarAvailable(reservation.SelectedCarId))
        {
            ModelState.AddModelError(nameof(reservation.SelectedCarId), "Seçilen araç müsait değil.");
        }

        if (!ModelState.IsValid)
        {
            reservation.Provinces = _sampleDataService.GetProvinces();
            return View(reservation);
        }

        var customer = _sampleDataService.GetCustomerByEmail(reservation.Email);

        if (customer == null)
        {
            customer = _sampleDataService.CreateCustomer(new Customer
            {
                FullName = reservation.FullName,
                Email = reservation.Email,
                PhoneNumber = reservation.PhoneNumber
            });
        }

        if (reservation.PickupDate.HasValue && reservation.ReturnDate.HasValue)
        {
            var newReservation = _sampleDataService.CreateReservation(new Reservation
            {
                CarId = reservation.SelectedCarId,
                CustomerId = customer.Id,
                PickupDate = reservation.PickupDate.Value,
                ReturnDate = reservation.ReturnDate.Value,
                PickupLocation = reservation.PickupLocation,
                Status = "Pending",
                TotalPrice = reservation.TotalPrice
            });

            return RedirectToAction(nameof(Success), new { id = newReservation.Id });
        }

        return RedirectToAction(nameof(Create), new { carId = reservation.SelectedCarId });
    }

    public IActionResult Success(int id)
    {
        var reservation = _sampleDataService.GetReservationById(id);
        if (reservation == null) return RedirectToAction(nameof(Create));

        var viewModel = new ReservationSuccessViewModel
        {
            ReservationId = reservation.Id,
            CustomerName = reservation.Customer?.FullName ?? "",
            CustomerEmail = reservation.Customer?.Email ?? "",
            CarBrand = reservation.Car?.Brand ?? "",
            CarModel = reservation.Car?.Model ?? "",
            PickupDate = reservation.PickupDate,
            ReturnDate = reservation.ReturnDate,
            PickupLocation = reservation.PickupLocation,
            RentalDays = (reservation.ReturnDate.Date - reservation.PickupDate.Date).Days,
            TotalPrice = reservation.TotalPrice,
            Status = reservation.Status
        };
        return View(viewModel);
    }

    private Car GetSelectedCar(int carId)
    {
        return _sampleDataService.GetCarById(carId) ?? _sampleDataService.GetCars().First();
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
