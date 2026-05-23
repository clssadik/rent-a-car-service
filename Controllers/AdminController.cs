using Microsoft.AspNetCore.Mvc;
using RentACarService.Models;
using RentACarService.ViewModels;

namespace RentACarService.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        var dashboard = new AdminDashboardViewModel
        {
            TotalCars = 24,
            ActiveReservations = 8,
            Customers = 56,
            TotalRevenue = 4820,
            RecentReservations = new List<ReservationSummaryViewModel>
            {
                new() { CustomerName = "Ayse Yilmaz", CarName = "Toyota Corolla", PickupDate = new DateTime(2026, 6, 1), ReturnDate = new DateTime(2026, 6, 4), Status = "Confirmed" },
                new() { CustomerName = "Mehmet Demir", CarName = "Volkswagen Golf", PickupDate = new DateTime(2026, 6, 3), ReturnDate = new DateTime(2026, 6, 5), Status = "Pending" },
                new() { CustomerName = "Elif Kaya", CarName = "Hyundai Tucson", PickupDate = new DateTime(2026, 6, 7), ReturnDate = new DateTime(2026, 6, 10), Status = "Completed" }
            }
        };

        return View(dashboard);
    }

    public IActionResult Cars()
    {
        var cars = new List<Car>
        {
            new() { Id = 1, Brand = "Toyota", Model = "Corolla", Year = 2022, DailyPrice = 45, IsAvailable = true },
            new() { Id = 2, Brand = "Volkswagen", Model = "Golf", Year = 2021, DailyPrice = 50, IsAvailable = true },
            new() { Id = 3, Brand = "Hyundai", Model = "Tucson", Year = 2023, DailyPrice = 75, IsAvailable = false }
        };

        return View(cars);
    }
}
