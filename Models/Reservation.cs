namespace RentACarService.Models;

public class Reservation
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public string PickupLocation { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending";

    public Car? Car { get; set; }
    public Customer? Customer { get; set; }
    public decimal TotalPrice { get; set; }
}
