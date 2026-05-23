namespace RentACarService.ViewModels;

public class AdminCustomersViewModel
{
    public List<AdminCustomerItem> Customers { get; set; } = [];
}

public class AdminCustomerItem
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public int ReservationCount { get; set; }
}
