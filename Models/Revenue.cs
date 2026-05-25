namespace RentACarService.Models;

public class Revenue
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int ReservationId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
