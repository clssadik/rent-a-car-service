namespace RentACarService.ViewModels;

public class AdminDashboardViewModel
{
    public int TotalCars { get; set; }
    public int ActiveReservations { get; set; }
    public int Customers { get; set; }
    public decimal TotalRevenue { get; set; }
    public List<ReservationSummaryViewModel> RecentReservations { get; set; } = new();
}
