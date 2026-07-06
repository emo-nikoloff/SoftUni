using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Data.Models.Enums;

namespace P02_FootballBetting.Data.Models;

public class Bet
{
    [Key]
    public int BetId { get; set; }

    [Column(TypeName = "DECIMAL(8, 2)")]
    public decimal Amount { get; set; }

    // SQL Server свързва енумерациите към INT по подразбиране. Ако искаме енумерацията да се свързва към друг тип данни - използва се value converter
    public Prediction Prediction { get; set; } // енумерациите (класът Prediction създаден от нас) по подразбиране са required

    [Column(TypeName = "DATETIME2")]
    public DateTime DateTime { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }

    public virtual Game Game { get; set; } = null!;
}
