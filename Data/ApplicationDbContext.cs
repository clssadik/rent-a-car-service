using Microsoft.EntityFrameworkCore;
using RentACarService.Models;

namespace RentACarService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Car> Cars => Set<Car>();
}
