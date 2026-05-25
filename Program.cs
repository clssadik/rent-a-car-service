using Microsoft.EntityFrameworkCore;
using RentACarService.Data;
using RentACarService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<RentACarService.Services.SampleDataService>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();

    if (!dbContext.Cars.Any(c => c.Brand == "Porsche"))
    {
        dbContext.Cars.Add(
            new Car
            {
                Brand = "Porsche",
                Model = "911 Turbo S",
                Year = 2024,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Type = "Coupe",
                SeatCount = 4,
                DailyPrice = 9800,
                IsAvailable = true,
                Description = "Porsche 911 Turbo S — 640 HP, 0-100 km/s 2.7 saniye, çift turbolu boxer motor. Üstün performans ve lüksün mükemmel birleşimi."
            });
    }

    if (!dbContext.Cars.Any(c => c.Brand == "Mercedes" && c.Model == "S Serisi"))
    {
        dbContext.Cars.Add(
            new Car
            {
                Brand = "Mercedes",
                Model = "S Serisi",
                Year = 2025,
                FuelType = "Diesel",
                Transmission = "Automatic",
                Type = "Sedan",
                SeatCount = 5,
                DailyPrice = 7950,
                IsAvailable = true,
                Description = "Mercedes-Benz S Serisi — lüks ve konforun zirvesi. En son teknoloji sürüş destek sistemleri, premium iç mekan ve üstün performans."
            });
    }

    if (!dbContext.Cars.Any(c => c.Brand == "Alfa Romeo" && c.Model == "Giulietta"))
    {
        dbContext.Cars.Add(
            new Car
            {
                Brand = "Alfa Romeo",
                Model = "Giulietta",
                Year = 2020,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Type = "Hatchback",
                SeatCount = 5,
                DailyPrice = 2850,
                IsAvailable = true,
                Description = "Sportif tasarimi ve kompakt yapisiyla sehir ici ve kisa yolculuklar icin keyifli bir hatchback secenegidir."
            });
    }

    if (!dbContext.Cars.Any(c => c.Brand == "Citroen" && c.Model == "C5"))
    {
        dbContext.Cars.Add(
            new Car
            {
                Brand = "Citroen",
                Model = "C5",
                Year = 2022,
                FuelType = "Diesel",
                Transmission = "Automatic",
                Type = "Sedan",
                SeatCount = 5,
                DailyPrice = 3600,
                IsAvailable = true,
                Description = "Konfor odakli surusu, genis ic hacmi ve ekonomik dizel motoruyla uzun yol kullanimi icin uygundur."
            });
    }

    if (!dbContext.Cars.Any(c => c.Brand == "Fiat" && c.Model == "Egea"))
    {
        dbContext.Cars.Add(
            new Car
            {
                Brand = "Fiat",
                Model = "Egea",
                Year = 2021,
                FuelType = "Diesel",
                Transmission = "Manual",
                Type = "Sedan",
                SeatCount = 5,
                DailyPrice = 2300,
                IsAvailable = true,
                Description = "Uygun fiyati, genis bagaj hacmi ve dusuk yakit tuketimiyle gunluk kiralama icin pratik bir sedan secenegidir."
            });
    }

    if (!dbContext.Cars.Any(c => c.Brand == "Renault" && c.Model == "Clio"))
    {
        dbContext.Cars.Add(
            new Car
            {
                Brand = "Renault",
                Model = "Clio",
                Year = 2022,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Type = "Hatchback",
                SeatCount = 5,
                DailyPrice = 2400,
                IsAvailable = true,
                Description = "Kompakt boyutlari ve kolay kullanimiyla sehir ici ulasimda ekonomik ve rahat bir tercihtir."
            });
    }

    if (!dbContext.Cars.Any(c => c.Brand == "Volkswagen" && c.Model == "Passat"))
    {
        dbContext.Cars.Add(
            new Car
            {
                Brand = "Volkswagen",
                Model = "Passat",
                Year = 2021,
                FuelType = "Diesel",
                Transmission = "Automatic",
                Type = "Sedan",
                SeatCount = 5,
                DailyPrice = 4200,
                IsAvailable = true,
                Description = "Genis kabini, dengeli surus karakteri ve premium hissiyle is seyahatleri ve aile kullanimi icin uygundur."
            });
    }

    if (!dbContext.Cars.Any(c => c.Brand == "Volvo" && c.Model == "XC90"))
    {
        dbContext.Cars.Add(
            new Car
            {
                Brand = "Volvo",
                Model = "XC90",
                Year = 2023,
                FuelType = "Hybrid",
                Transmission = "Automatic",
                Type = "SUV",
                SeatCount = 7,
                DailyPrice = 8900,
                IsAvailable = true,
                Description = "Yedi koltuklu yapisi, hibrit motoru ve gelismis guvenlik donanimlariyla luks SUV segmentinde guclu bir alternatiftir."
            });
    }

    dbContext.SaveChanges();

    if (!dbContext.Provinces.Any())
    {
        var provinces = new[] { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kilis", "Kırıkkale", "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Şanlıurfa", "Siirt", "Sinop", "Şırnak", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" };
        foreach (var p in provinces)
            dbContext.Provinces.Add(new Province { Name = p });
        dbContext.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
