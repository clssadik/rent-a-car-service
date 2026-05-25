using System.ComponentModel.DataAnnotations;
using RentACarService.Models;

namespace RentACarService.ViewModels;

public class ReservationCreateViewModel
{
    public Car SelectedCar { get; set; } = new();

    public List<Province> Provinces { get; set; } = new();

    public int SelectedCarId { get; set; }

    public int RentalDays { get; set; }

    [Required(ErrorMessage = "Ad soyad zorunludur.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "E-posta zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefon numarası zorunludur.")]
    [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Alış tarihi zorunludur.")]
    [DataType(DataType.Date)]
    public DateTime? PickupDate { get; set; }

    [Required(ErrorMessage = "İade tarihi zorunludur.")]
    [DataType(DataType.Date)]
    public DateTime? ReturnDate { get; set; }

    [Required(ErrorMessage = "Alış lokasyonu zorunludur.")]
    public string PickupLocation { get; set; } = string.Empty;

    public int TotalPrice => SelectedCar.DailyPrice * RentalDays;
}
