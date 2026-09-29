using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GarageApp.Data.Models;

namespace GarageApp.Data.Configuration;

public class GarageConfiguration : IEntityTypeConfiguration<Garage>
{
    public static IEnumerable<Garage> Garages => new List<Garage>
    {
        new Garage
        {
            Id = 1,
            Name = "Auto Center Sofia",
            Location = "Sofia, Bulgaria"
        },
        new Garage
        {
            Id = 2,
            Name = "Plovdiv Motors",
            Location = "Plovdiv, Bulgaria"
        },
        new Garage
        {
            Id = 3,
            Name = "Black Sea Garage",
            Location = "Varna, Bulgaria"
        }
    };

    public void Configure(EntityTypeBuilder<Garage> builder)
    {
        builder.HasData(Garages);
    }
}
