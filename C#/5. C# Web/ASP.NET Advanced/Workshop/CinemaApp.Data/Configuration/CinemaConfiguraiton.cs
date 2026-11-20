using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Configuration;

public class CinemaConfiguraiton : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.HasQueryFilter(c => c.IsDeleted == false);
    }
}
