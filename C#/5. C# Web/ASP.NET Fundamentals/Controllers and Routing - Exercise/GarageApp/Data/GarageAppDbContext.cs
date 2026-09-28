using Microsoft.EntityFrameworkCore;

using GarageApp.Data.Models;

namespace GarageApp.Data;

public class GarageAppDbContext : DbContext
{
    public GarageAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; } = null!;
    public virtual DbSet<Garage> Garages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GarageAppDbContext).Assembly);
    }
}
