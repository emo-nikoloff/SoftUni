using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CinemaApp.Data.Models;

namespace CinemaApp.Data.Configuration;

public class UserTicketConfiguration : IEntityTypeConfiguration<UserTicket>
{
    public void Configure(EntityTypeBuilder<UserTicket> builder)
    {
        builder.HasQueryFilter(ut => ut.Ticket.Projection.IsDeleted == false);
    }
}