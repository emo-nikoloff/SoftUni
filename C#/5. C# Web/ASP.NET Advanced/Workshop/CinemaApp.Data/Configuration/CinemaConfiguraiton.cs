using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Configuration;

public class CinemaConfiguraiton : IEntityTypeConfiguration<Cinema>
{
    public static readonly IEnumerable<Cinema> CinemaSeedData = new List<Cinema>()
    {
        new Cinema
        {
            Id = Guid.Parse("d2c5e0a1-9c9b-4a80-8d76-5c0e0a4a2f11"),
            Name = "Arena Cinema",
            Location = "Sofia"
        },
        new Cinema
        {
            Id = Guid.Parse("a7f3b2c8-6e14-4d55-9f2a-1b8c7e6d3a90"),
            Name = "Cine Grand",
            Location = "Plovdiv"
        },
        new Cinema
        {
            Id = Guid.Parse("4e8d1c6b-2f75-4a39-b0e6-9c3d5f7a8214"),
            Name = "Movie Park",
            Location = "Varna"
        },
    };

    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.HasQueryFilter(c => c.IsDeleted == false);

        builder.HasData(CinemaSeedData);
    }
}
