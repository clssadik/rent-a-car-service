using Microsoft.EntityFrameworkCore;
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

    public List<Province> GetProvinces()
    {
        return _dbContext.Provinces.OrderBy(p => p.Name).ToList();
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
            "0-5000" => cars.Where(car => car.DailyPrice <= 5000),
            "5000-9000" => cars.Where(car => car.DailyPrice > 5000 && car.DailyPrice <= 9000),
            "9000+" => cars.Where(car => car.DailyPrice > 9000),
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

    public Customer CreateCustomer(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        _dbContext.SaveChanges();
        return customer;
    }

    public Customer? GetCustomerByEmail(string email)
    {
        return _dbContext.Customers.FirstOrDefault(c => c.Email == email);
    }

    public Reservation CreateReservation(Reservation reservation)
    {
        _dbContext.Reservations.Add(reservation);
        _dbContext.SaveChanges();
        return reservation;
    }

    public List<ReservationSummaryViewModel> GetRecentReservations()
    {
        return _dbContext.Reservations
            .OrderByDescending(r => r.PickupDate)
            .Take(5)
            .Select(r => new ReservationSummaryViewModel
            {
                Id = r.Id,
                CustomerName = r.Customer != null ? r.Customer.FullName : "",
                CarName = r.Car != null ? r.Car.Brand + " " + r.Car.Model : "",
                PickupDate = r.PickupDate,
                ReturnDate = r.ReturnDate,
                Status = r.Status
            })
            .ToList();
    }

    public int GetTotalReservations()
    {
        return _dbContext.Reservations.Count();
    }

    public int GetTotalCustomers()
    {
        return _dbContext.Customers.Count();
    }

    public Reservation? GetReservationById(int id)
    {
        return _dbContext.Reservations
            .Include(r => r.Car)
            .Include(r => r.Customer)
            .FirstOrDefault(r => r.Id == id);
    }

    public decimal GetTotalRevenue()
    {
        return _dbContext.Revenues.Sum(r => r.Amount);
    }

    public bool HasOverlappingReservation(int carId, DateTime pickupDate, DateTime returnDate)
    {
        return _dbContext.Reservations.Any(r =>
            r.CarId == carId &&
            r.Status != "Cancelled" &&
            pickupDate < r.ReturnDate && returnDate > r.PickupDate);
    }

    public bool IsCarAvailable(int carId)
    {
        var car = _dbContext.Cars.FirstOrDefault(c => c.Id == carId);
        return car != null && car.IsAvailable;
    }

    public List<AdminReservationItem> GetAllReservations()
    {
        return _dbContext.Reservations
            .Include(r => r.Car)
            .Include(r => r.Customer)
            .OrderByDescending(r => r.PickupDate)
            .Select(r => new AdminReservationItem
            {
                Id = r.Id,
                CustomerName = r.Customer != null ? r.Customer.FullName : "",
                CarName = r.Car != null ? r.Car.Brand + " " + r.Car.Model : "",
                PickupDate = r.PickupDate,
                ReturnDate = r.ReturnDate,
                PickupLocation = r.PickupLocation,
                Status = r.Status,
                TotalPrice = r.TotalPrice
            })
            .ToList();
    }

    public bool UpdateReservationStatus(int id, string status)
    {
        var reservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null) return false;
        reservation.Status = status;

        if (status == "Confirmed" && !_dbContext.Revenues.Any(r => r.ReservationId == id))
        {
            _dbContext.Revenues.Add(new Revenue
            {
                Amount = reservation.TotalPrice,
                ReservationId = id,
                CreatedAt = DateTime.UtcNow
            });
        }

        _dbContext.SaveChanges();
        return true;
    }

    public List<AdminCustomerItem> GetAllCustomers()
    {
        return _dbContext.Customers
            .OrderBy(c => c.FullName)
            .Select(c => new AdminCustomerItem
            {
                Id = c.Id,
                FullName = c.FullName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                ReservationCount = c.Reservations.Count
            })
            .ToList();
    }
}
