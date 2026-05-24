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
        dbContext.Cars.AddRange(
            new Car
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2022,
                FuelType = "Gasoline",
                Transmission = "Automatic",
                Type = "Sedan",
                SeatCount = 5,
                DailyPrice = 45,
                IsAvailable = true,
                Description = "A comfortable sedan with low fuel consumption, practical luggage space, and smooth automatic transmission. Suitable for city driving and short trips."
            },
            new Car
            {
                Brand = "Volkswagen",
                Model = "Golf",
                Year = 2021,
                FuelType = "Diesel",
                Transmission = "Manual",
                Type = "Hatchback",
                SeatCount = 5,
                DailyPrice = 50,
                IsAvailable = true,
                Description = "A compact hatchback with practical handling and efficient fuel usage."
            },
            new Car
            {
                Brand = "Hyundai",
                Model = "Tucson",
                Year = 2023,
                FuelType = "Hybrid",
                Transmission = "Automatic",
                Type = "SUV",
                SeatCount = 5,
                DailyPrice = 75,
                IsAvailable = false,
                Description = "A modern SUV with a comfortable interior and hybrid efficiency."
            },
            new Car
            {
                Brand = "Renault",
                Model = "Clio",
                Year = 2020,
                FuelType = "Gasoline",
                Transmission = "Manual",
                Type = "Hatchback",
                SeatCount = 5,
                DailyPrice = 38,
                IsAvailable = true,
                Description = "A budget-friendly hatchback for city trips."
            },
            new Car
            {
                Brand = "Ford",
                Model = "Focus",
                Year = 2022,
                FuelType = "Diesel",
                Transmission = "Automatic",
                Type = "Sedan",
                SeatCount = 5,
                DailyPrice = 55,
                IsAvailable = true,
                Description = "A reliable sedan with balanced comfort and performance."
            },
            new Car
            {
                Brand = "Mercedes",
                Model = "Vito",
                Year = 2021,
                FuelType = "Diesel",
                Transmission = "Automatic",
                Type = "Van",
                SeatCount = 8,
                DailyPrice = 90,
                IsAvailable = false,
                Description = "A spacious van suitable for family and group travel."
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
