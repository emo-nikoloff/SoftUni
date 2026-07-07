using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MusicHub.Data.Models;
using static MusicHub.Common.EntityValidation;

namespace MusicHub.Data.EntityConfiguration;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> entity)
    {
        entity.HasKey(a => a.Id);

        entity.Property(a => a.Name)
            .IsRequired(true)
            .HasMaxLength(AlbumNameMaxLength);

        entity.Property(a => a.ReleaseDate)
            .HasColumnType(AlbumRealeaseDateColumnType);

        entity.Ignore(a => a.Price); // Price пропърти не трябва да бъде свързано към DB колона! (Calculated Property в клиента)

        entity.HasOne(a => a.Producer)
            .WithMany(p => p.Albums)
            .HasForeignKey(a => a.ProducerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
