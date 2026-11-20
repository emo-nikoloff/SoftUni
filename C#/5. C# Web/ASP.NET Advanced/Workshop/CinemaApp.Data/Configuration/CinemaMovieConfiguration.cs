using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Configuration;

public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
{
    public void Configure(EntityTypeBuilder<CinemaMovie> builder)
    {
        builder.HasQueryFilter(cm => cm.IsDeleted == false &&
            cm.Cinema.IsDeleted == false &&
            cm.Movie.IsDeleted == false);
    }
}
