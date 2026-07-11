using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

// EF Core 7.0+ -> [PrimaryKey(nameof(GameId), nameof(PlayerId))]
public class PlayerStatistic
{
    // За целта на упражнението ще се придържаме към по-старите версии на EF Core и ще създадем композитен Primay Key във Fluent API конфигурацията
    // Навигационните пропъртита стоят в mapping entity, когато използваме такова (в този случай)

    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }

    public virtual Game Game { get; set; } = null!;

    [ForeignKey(nameof(Player))]
    public int PlayerId { get; set; }

    public virtual Player Player { get; set; } = null!;

    public byte ScoredGoals { get; set; }

    public byte Assists { get; set; }

    public byte MinutesPlayed { get; set; }
}
