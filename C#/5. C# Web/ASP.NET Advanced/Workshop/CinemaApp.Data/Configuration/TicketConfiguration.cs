using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasQueryFilter(t => t.Projection.IsDeleted == false);
    }
}
