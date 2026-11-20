using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Configuration;

public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
{
    public static readonly IEnumerable<CinemaMovie> CinemaMovieSeedData = new List<CinemaMovie>()
    {
        new CinemaMovie
        {
            Id = Guid.Parse("b1f4a8d2-3c67-4e90-8a15-6d2f7c9b0e41"),
            CinemaId = Guid.Parse("d2c5e0a1-9c9b-4a80-8d76-5c0e0a4a2f11"),
            MovieId = Guid.Parse("4571bf2f-dbb3-446c-a92a-07cb77f47ed0"),
            AvailableTickets = 120,
            Showtime = new DateTime(2026, 12, 1, 18, 30, 0)
        },
        new CinemaMovie
        {
            Id = Guid.Parse("e6c2b9f7-1a54-4d83-b028-9f7e3c6a5d12"),
            CinemaId = Guid.Parse("a7f3b2c8-6e14-4d55-9f2a-1b8c7e6d3a90"),
            MovieId = Guid.Parse("e673a37c-8ffc-46bf-a66d-18b8078d7c94"),
            AvailableTickets = 100,
            Showtime = new DateTime(2026, 12, 2, 20, 0, 0)
        },
        new CinemaMovie
        {
            Id = Guid.Parse("8d3f6b1a-5e92-47c0-a684-2b9f7d4e1c53"),
            CinemaId = Guid.Parse("4e8d1c6b-2f75-4a39-b0e6-9c3d5f7a8214"),
            MovieId = Guid.Parse("2f22c0dd-f7b9-46c3-a753-0d076dafb489"),
            AvailableTickets = 150,
            Showtime = new DateTime(2026, 12, 3, 19, 15, 0)
        },
    };

    public void Configure(EntityTypeBuilder<CinemaMovie> builder)
    {
        builder.HasQueryFilter(cm => cm.IsDeleted == false &&
            cm.Cinema.IsDeleted == false &&
            cm.Movie.IsDeleted == false);

        builder.HasIndex(cm => new
        {
            cm.CinemaId,
            cm.MovieId,
            cm.Showtime,
        })
        .IsUnique();

        builder.HasData(CinemaMovieSeedData);
    }
}
