namespace RentACarService.ViewModels;

public class ReservationSuccessViewModel
{
    public int ReservationId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CarBrand { get; set; } = string.Empty;
    public string CarModel { get; set; } = string.Empty;
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string PickupLocation { get; set; } = string.Empty;
    public int RentalDays { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = string.Empty;
}
