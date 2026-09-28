using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GarageApp.Data.Models;
using GarageApp.Data.Models.Enums;

namespace GarageApp.Data.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public static IEnumerable<Car> Cars => new List<Car>
    {
        new Car
        {
            Id = 1,
            Make = "Toyota",
            Model = "Corolla",
            ProductionMonth = 5,
            Year = 2021,
            Type = CarType.Sedan,
            IsAvailable = true,
            GarageId = 1
        },
        new Car
        {
            Id = 2,
            Make = "Volkswagen",
            Model = "Golf",
            ProductionMonth = 9,
            Year = 2019,
            Type = CarType.Hatchback,
            IsAvailable = true,
            GarageId = 1
        },
        new Car
        {
            Id = 3,
            Make = "BMW",
            Model = "X5",
            ProductionMonth = 2,
            Year = 2022,
            Type = CarType.SUV,
            IsAvailable = false,
            GarageId = 2
        },
        new Car
        {
            Id = 4,
            Make = "Ford",
            Model = "Transit",
            ProductionMonth = 11,
            Year = 2020,
            Type = CarType.Van,
            IsAvailable = true,
            GarageId = 3
        }
    };

    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(Cars);
    }
}
