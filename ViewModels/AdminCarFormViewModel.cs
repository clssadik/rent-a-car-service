using System.ComponentModel.DataAnnotations;

namespace RentACarService.ViewModels;

public class AdminCarFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Marka zorunludur.")]
    public string Brand { get; set; } = string.Empty;

    [Required(ErrorMessage = "Model zorunludur.")]
    public string Model { get; set; } = string.Empty;

    [Range(2000, 2030, ErrorMessage = "Yıl 2000-2030 arasında olmalıdır.")]
    public int Year { get; set; }

    [Required(ErrorMessage = "Yakıt tipi zorunludur.")]
    public string FuelType { get; set; } = "Gasoline";

    [Required(ErrorMessage = "Vites zorunludur.")]
    public string Transmission { get; set; } = "Automatic";

    [Required(ErrorMessage = "Araç tipi zorunludur.")]
    public string Type { get; set; } = "Sedan";

    [Range(1, 20, ErrorMessage = "Koltuk sayısı 1-20 arasında olmalıdır.")]
    public int SeatCount { get; set; }

    [Range(1, 100000, ErrorMessage = "Günlük fiyat 0'dan büyük olmalıdır.")]
    public int DailyPrice { get; set; }

    [Url(ErrorMessage = "Geçerli bir görsel URL'si girin.")]
    public string? ImageUrl { get; set; }

    public bool IsAvailable { get; set; } = true;
}
