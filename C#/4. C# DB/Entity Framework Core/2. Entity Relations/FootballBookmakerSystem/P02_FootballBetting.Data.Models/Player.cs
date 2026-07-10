using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Player
{
    [Key]
    public int PlayerId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = null!;

    public byte SquadNumber { get; set; }

    public bool IsInjured { get; set; } = false; /* in-memory стойност по подразбиране; не е задължително да се задава, понеже стойността на bool по подразбиране е false 
                                                    ако искаме стойността по подразбиране да се задава в базата, трябва да използваме Fluent API (.HasDefaultValueSql())*/

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }

    public virtual Position Position { get; set; } = null!;

    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }

    public virtual Team Team { get; set; } = null!;

    [ForeignKey(nameof(Town))]
    public int TownId { get; set; }

    public virtual Town Town { get; set; } = null!;

    public virtual ICollection<PlayerStatistic> PlayersStatistics { get; set; } = new HashSet<PlayerStatistic>();
}
