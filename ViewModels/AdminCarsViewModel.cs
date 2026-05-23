using RentACarService.Models;

namespace RentACarService.ViewModels;

public class AdminCarsViewModel
{
    public List<Car> Cars { get; set; } = new();
    public AdminCarFormViewModel Form { get; set; } = new();
}
