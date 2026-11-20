using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Common.Models;
using static CinemaApp.Data.Common.EntityValidation.CinemaMovie;

namespace CinemaApp.Data.Models;

[PrimaryKey(nameof(CinemaId), nameof(MovieId))]
public class CinemaMovie : ISoftDeletableEntity
{
    [ForeignKey(nameof(Cinema))]
    public Guid CinemaId { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    [ForeignKey(nameof(Movie))]
    public Guid MovieId { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public int AvailableTickets { get; set; }

    public bool IsDeleted { get; set; }

    [Column(TypeName = ShowtimeColumnType)]
    public DateTime Showtime { get; set; }
}
