using Microsoft.EntityFrameworkCore;

using GameZone.Data.Models;

namespace GameZone.Data;

public class GameZoneDbContext : DbContext
{
    public GameZoneDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Genre> Genres { get; set; } = null!;

    public virtual DbSet<Game> Games { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameZoneDbContext).Assembly);
    }
}
