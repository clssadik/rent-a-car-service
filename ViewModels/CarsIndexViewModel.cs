using RentACarService.Models;

namespace RentACarService.ViewModels;

public class CarsIndexViewModel
{
    public List<Car> Cars { get; set; } = new();
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public string? Transmission { get; set; }
    public string? PriceRange { get; set; }
}
