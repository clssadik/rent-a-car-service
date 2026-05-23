using System.ComponentModel.DataAnnotations;

namespace RentACarService.ViewModels;

public class AdminCarFormViewModel
{
    [Required(ErrorMessage = "Brand is required.")]
    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Model is required.")]
    public string Model { get; set; } = string.Empty;

    [Range(2000, 2030, ErrorMessage = "Year must be between 2000 and 2030.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Fuel type is required.")]
    public string FuelType { get; set; } = "Gasoline";

    [Required(ErrorMessage = "Transmission is required.")]
    public string Transmission { get; set; } = "Automatic";

    [Required(ErrorMessage = "Car type is required.")]
    public string Type { get; set; } = "Sedan";

    [Range(1, 20, ErrorMessage = "Seat count must be between 1 and 20.")]
    public int SeatCount { get; set; }

    [Range(1, 1000, ErrorMessage = "Daily price must be greater than 0.")]
    public int DailyPrice { get; set; }

    [Url(ErrorMessage = "Please enter a valid image URL.")]
    public string? ImageUrl { get; set; }

    public bool IsAvailable { get; set; } = true;
}
