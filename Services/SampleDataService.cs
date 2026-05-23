using RentACarService.Models;
using RentACarService.ViewModels;

namespace RentACarService.Services;

public class SampleDataService
{
    private readonly List<Car> _cars =
    [
        new()
        {
            Id = 1,
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2022,
            FuelType = "Gasoline",
            Transmission = "Automatic",
            Type = "Sedan",
            SeatCount = 5,
            DailyPrice = 45,
            IsAvailable = true,
            Description = "A comfortable sedan with low fuel consumption, practical luggage space, and smooth automatic transmission. Suitable for city driving and short trips."
        },
        new()
        {
            Id = 2,
            Brand = "Volkswagen",
            Model = "Golf",
            Year = 2021,
            FuelType = "Diesel",
            Transmission = "Manual",
            Type = "Hatchback",
            SeatCount = 5,
            DailyPrice = 50,
            IsAvailable = true,
            Description = "A compact hatchback with practical handling and efficient fuel usage."
        },
        new()
        {
            Id = 3,
            Brand = "Hyundai",
            Model = "Tucson",
            Year = 2023,
            FuelType = "Hybrid",
            Transmission = "Automatic",
            Type = "SUV",
            SeatCount = 5,
            DailyPrice = 75,
            IsAvailable = false,
            Description = "A modern SUV with a comfortable interior and hybrid efficiency."
        },
        new()
        {
            Id = 4,
            Brand = "Renault",
            Model = "Clio",
            Year = 2020,
            FuelType = "Gasoline",
            Transmission = "Manual",
            Type = "Hatchback",
            SeatCount = 5,
            DailyPrice = 38,
            IsAvailable = true,
            Description = "A budget-friendly hatchback for city trips."
        },
        new()
        {
            Id = 5,
            Brand = "Ford",
            Model = "Focus",
            Year = 2022,
            FuelType = "Diesel",
            Transmission = "Automatic",
            Type = "Sedan",
            SeatCount = 5,
            DailyPrice = 55,
            IsAvailable = true,
            Description = "A reliable sedan with balanced comfort and performance."
        },
        new()
        {
            Id = 6,
            Brand = "Mercedes",
            Model = "Vito",
            Year = 2021,
            FuelType = "Diesel",
            Transmission = "Automatic",
            Type = "Van",
            SeatCount = 8,
            DailyPrice = 90,
            IsAvailable = false,
            Description = "A spacious van suitable for family and group travel."
        }
    ];

    private readonly List<ReservationSummaryViewModel> _recentReservations =
    [
        new() { CustomerName = "Ayse Yilmaz", CarName = "Toyota Corolla", PickupDate = new DateTime(2026, 6, 1), ReturnDate = new DateTime(2026, 6, 4), Status = "Confirmed" },
        new() { CustomerName = "Mehmet Demir", CarName = "Volkswagen Golf", PickupDate = new DateTime(2026, 6, 3), ReturnDate = new DateTime(2026, 6, 5), Status = "Pending" },
        new() { CustomerName = "Elif Kaya", CarName = "Hyundai Tucson", PickupDate = new DateTime(2026, 6, 7), ReturnDate = new DateTime(2026, 6, 10), Status = "Completed" }
    ];

    public List<Car> GetCars()
    {
        return _cars;
    }

    public List<Car> GetFeaturedCars()
    {
        return _cars.Take(3).ToList();
    }

    public Car? GetCarById(int id)
    {
        return _cars.FirstOrDefault(car => car.Id == id);
    }

    public List<ReservationSummaryViewModel> GetRecentReservations()
    {
        return _recentReservations;
    }
}
