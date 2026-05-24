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

    if (!dbContext.Cars.Any())
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
                DailyPrice = 350,
                IsAvailable = true,
                Description = "Porsche 911 Turbo S — 640 HP, 0-100 km/s 2.7 saniye, çift turbolu boxer motor. Üstün performans ve lüksün mükemmel birleşimi."
            });

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
                DailyPrice = 480,
                IsAvailable = true,
                Description = "Mercedes-Benz S Serisi — lüks ve konforun zirvesi. En son teknoloji sürüş destek sistemleri, premium iç mekan ve üstün performans."
            });

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
