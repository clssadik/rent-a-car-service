using System.ComponentModel.DataAnnotations;
using RentACarService.Models;

namespace RentACarService.ViewModels;

public class ReservationCreateViewModel
{
    public Car SelectedCar { get; set; } = new();

    public int SelectedCarId { get; set; }

    public int RentalDays { get; set; }

    [Required(ErrorMessage = "Full name is required.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Pickup date is required.")]
    [DataType(DataType.Date)]
    public DateTime? PickupDate { get; set; }

    [Required(ErrorMessage = "Return date is required.")]
    [DataType(DataType.Date)]
    public DateTime? ReturnDate { get; set; }

    [Required(ErrorMessage = "Pickup location is required.")]
    public string PickupLocation { get; set; } = string.Empty;

    public int TotalPrice => SelectedCar.DailyPrice * RentalDays;
}
