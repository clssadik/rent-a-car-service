namespace RentACarService.ViewModels;

public class ReservationSummaryViewModel
{
    public string CustomerName { get; set; } = string.Empty;
    public string CarName { get; set; } = string.Empty;
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string Status { get; set; } = string.Empty;
}
