namespace RentACarService.ViewModels;

public class AdminReservationsViewModel
{
    public List<AdminReservationItem> Reservations { get; set; } = [];
    public decimal TotalRevenue { get; set; }
}

public class AdminReservationItem
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CarName { get; set; } = string.Empty;
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string PickupLocation { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
}
