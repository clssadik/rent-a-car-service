using RentACarService.Models;

namespace RentACarService.ViewModels;

public class CarsIndexViewModel
{
    public List<Car> Cars { get; set; } = new();
}
