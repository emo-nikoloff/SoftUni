using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Configuration;

public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
{
    public void Configure(EntityTypeBuilder<UserMovie> builder)
    {
        // Low performance solution: Прилага overhead поради извличане на Movie.IsDeleted на всеки request
        builder.HasQueryFilter(um => um.Movie.IsDeleted == false);
    }
}
