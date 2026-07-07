using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models;

public class Song
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public TimeSpan Duration { get; set; } // required по подразбиране; може да бъде конвертиран в long (Ticks) или string (Invariant Culture) DB Types

    public DateTime CreatedOn { get; set; }

    // PostgreSQL предлага ENUM DB Type, ако използвате custom ValueConverter в EF Core
    public Genre Genre { get; set; } // понеже енумерациите са числови стойности, те са required по подразбиране; енумерацията се конвертира в INT SQL Type (SQLServer)

    public int? AlbumId { get; set; }

    public virtual Album? Album { get; set; }

    public int WriterId { get; set; }

    public virtual Writer Writer { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<SongPerformer> SongPerformers { get; set; } = new HashSet<SongPerformer>();
}
