using RentACarService.Models;

namespace RentACarService.ViewModels;

public class ReservationCreateViewModel
{
    public Car SelectedCar { get; set; } = new();
    public int RentalDays { get; set; }
    public int TotalPrice => SelectedCar.DailyPrice * RentalDays;
}
