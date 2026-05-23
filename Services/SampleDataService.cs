using RentACarService.Models;
using RentACarService.Data;
using RentACarService.ViewModels;

namespace RentACarService.Services;

public class SampleDataService
{
    private readonly ApplicationDbContext _dbContext;

    private readonly List<ReservationSummaryViewModel> _recentReservations =
    [
        new() { CustomerName = "Ayse Yilmaz", CarName = "Toyota Corolla", PickupDate = new DateTime(2026, 6, 1), ReturnDate = new DateTime(2026, 6, 4), Status = "Confirmed" },
        new() { CustomerName = "Mehmet Demir", CarName = "Volkswagen Golf", PickupDate = new DateTime(2026, 6, 3), ReturnDate = new DateTime(2026, 6, 5), Status = "Pending" },
        new() { CustomerName = "Elif Kaya", CarName = "Hyundai Tucson", PickupDate = new DateTime(2026, 6, 7), ReturnDate = new DateTime(2026, 6, 10), Status = "Completed" }
    ];

    public SampleDataService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Car> GetCars()
    {
        return _dbContext.Cars.OrderBy(car => car.Id).ToList();
    }

    public void AddCar(Car car)
    {
        _dbContext.Cars.Add(car);
        _dbContext.SaveChanges();
    }

    public bool DeleteCar(int id)
    {
        var car = GetCarById(id);

        if (car == null)
        {
            return false;
        }

        _dbContext.Cars.Remove(car);
        _dbContext.SaveChanges();

        return true;
    }

    public bool UpdateCar(Car updatedCar)
    {
        var car = GetCarById(updatedCar.Id);

        if (car == null)
        {
            return false;
        }

        car.Brand = updatedCar.Brand;
        car.Model = updatedCar.Model;
        car.Year = updatedCar.Year;
        car.FuelType = updatedCar.FuelType;
        car.Transmission = updatedCar.Transmission;
        car.Type = updatedCar.Type;
        car.SeatCount = updatedCar.SeatCount;
        car.DailyPrice = updatedCar.DailyPrice;
        car.ImageUrl = updatedCar.ImageUrl;
        car.IsAvailable = updatedCar.IsAvailable;
        car.Description = updatedCar.Description;

        _dbContext.SaveChanges();

        return true;
    }

    public List<Car> GetFilteredCars(string? brand, string? type, string? transmission, string? priceRange)
    {
        var cars = _dbContext.Cars.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(brand))
        {
            cars = cars.Where(car => car.Brand.Contains(brand, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(type))
        {
            cars = cars.Where(car => car.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(transmission))
        {
            cars = cars.Where(car => car.Transmission.Equals(transmission, StringComparison.OrdinalIgnoreCase));
        }

        cars = priceRange switch
        {
            "0-50" => cars.Where(car => car.DailyPrice <= 50),
            "50-80" => cars.Where(car => car.DailyPrice > 50 && car.DailyPrice <= 80),
            "80+" => cars.Where(car => car.DailyPrice > 80),
            _ => cars
        };

        return cars.ToList();
    }

    public List<Car> GetFeaturedCars()
    {
        return _dbContext.Cars.OrderBy(car => car.Id).Take(3).ToList();
    }

    public Car? GetCarById(int id)
    {
        return _dbContext.Cars.FirstOrDefault(car => car.Id == id);
    }

    public List<ReservationSummaryViewModel> GetRecentReservations()
    {
        return _recentReservations;
    }
}
