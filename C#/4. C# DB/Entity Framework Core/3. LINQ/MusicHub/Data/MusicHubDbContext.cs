using Microsoft.EntityFrameworkCore;

using MusicHub.Data.EntityConfiguration;
using MusicHub.Data.Models;

namespace MusicHub.Data;

public class MusicHubDbContext : DbContext
{
    public MusicHubDbContext()
    {
    }

    public MusicHubDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Song> Songs { get; set; } = null!;

    public virtual DbSet<Album> Albums { get; set; } = null!;

    public virtual DbSet<Performer> Performers { get; set; } = null!;

    public virtual DbSet<Producer> Producers { get; set; } = null!;

    public virtual DbSet<Writer> Writers { get; set; } = null!;

    public virtual DbSet<SongPerformer> SongsPerformers { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Configuration.ConnectionString); /* архитектурна практика - connection string е в отделен клас Configuration, за да не се лийкне в
                                                                                              source code*/
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /* Непрактичен вариант при наличие на много конфигурации
        modelBuilder.ApplyConfiguration(new SongConfiguration());
        modelBuilder.ApplyConfiguration(new AlbumConfiguration());
        modelBuilder.ApplyConfiguration(new PerformerConfiguration());
        modelBuilder.ApplyConfiguration(new ProducerConfiguration());
        modelBuilder.ApplyConfiguration(new WriterConfiguration());
        modelBuilder.ApplyConfiguration(new SongPerformerConfiguration());
        */

        // Конвенция: ако всички конфигурации се намират в едно и също асембли, това ще се изпълни без проблеми
        // Конвенция: всички конфигурации се намират в едно и също асембли
        // Подаваме асемблито на случайна конфигурация 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SongConfiguration).Assembly); /* взимаме типа на случайна конфигирации, след това извикваме асемблито и го подаваме на 
                                                                                                       функцията */
    }
}