using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public static readonly IEnumerable<Ticket> TicketSeedData = new List<Ticket>()
    {
        new Ticket
        {
            Id = Guid.Parse("f1a2b3c4-d5e6-4789-a012-3456789abcde"),
            Price = 12.50m,
            ProjectionId = Guid.Parse("b1f4a8d2-3c67-4e90-8a15-6d2f7c9b0e41"),
        },
        new Ticket
        {
            Id = Guid.Parse("a2b3c4d5-e6f7-4890-ab12-3456789abcde"),
            Price = 12.50m,
            ProjectionId = Guid.Parse("e6c2b9f7-1a54-4d83-b028-9f7e3c6a5d12"),
        },
        new Ticket
        {
            Id = Guid.Parse("b3c4d5e6-f7a8-4901-bc23-456789abcdef"),
            Price = 12.50m,
            ProjectionId = Guid.Parse("8d3f6b1a-5e92-47c0-a684-2b9f7d4e1c53"),
        },
    };

    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasQueryFilter(t => t.Projection.IsDeleted == false);

        builder.HasData(TicketSeedData);
    }
}
