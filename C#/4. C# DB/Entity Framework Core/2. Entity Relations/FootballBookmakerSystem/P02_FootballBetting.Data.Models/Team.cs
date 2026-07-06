using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models;

public class Team
{
    [Key]
    public int TeamId { get; set; } // по конвенция това се приема за Primary Key; [Key] е експлицитно задаване на Primary Key

    [Required]
    [MaxLength(70)]
    public string Name { get; set; } = null!; /* = null! - премахва предупреждението за nullable; след public може да се сложи required, за да обозначи колоната като non-nullable; [Required] -
                                                 обозначава колоната като non-nullable и е добре да се използва за по-високо backwards compatibility и четимост; по подразбиране EF Core сам се
                                                 досеща, че колоната е required */

    [MaxLength(2048)]
    public string? LogoUrl { get; set; }

    [Required]
    [MaxLength(4)]
    public string Initials { get; set; } = null!;

    [Column(TypeName = "DECIMAL(12, 3)")] // експлицитно задаване на типа на променливата
    public decimal Budget { get; set; } // decimal е required по подразбиране

    [ForeignKey(nameof(PrimaryKitColor))] /* Foreign Key сочи към навигационното пропърти. Други начини за задаване на Foreign Key са: 
                                                  1. Върху навигационното пропърти като сочи към ключа
                                                  2. Върху навигационната колекция като сочи към ключа
                                                  3. Fluent API */
    public int PrimaryKitColorId { get; set; }

    public virtual Color PrimaryKitColor { get; set; } = null!; /* използваме навигационно пропърти, защото 1 отбор има 1 главен екип/1 второстепенен екип; правим навигационното пропърти virtual,
                                                                   заради Lazy Loading - по време на изпълнение EF Core създава невидим клас (Dynamic Proxy), който наследява съответния клас
                                                                   (в случая Team). Този клас презаписва навигационното пропърти, като вмъква допълнителна логика и прави следното:
                                                                   "Ако цветът на отбора не е зареден предварително, при първото му поискване в програмата, EF Core динамично изпълнява нова заявка
                                                                   към базата данни, за да го изтегли 'в движение', преди да продължи изпълнението.". Така не се налага да се пише постоянно
                                                                   .Include(t => t.PrimaryKitColor) - данните се изтеглят автоматично точно в момента, в който бъдат поискани. Lazy Loading е
                                                                   изключен по подразбиране. За да бъде активиран трябва да се използва .UseLazyLoadingProxies() от пакета
                                                                   Microsoft.EntityFrameworkCore.Proxies в .OnConfiguring(). Накратко прави скрити заявки към базата */

    [ForeignKey(nameof(SecondaryKitColor))]
    public int SecondaryKitColorId { get; set; }

    public virtual Color SecondaryKitColor { get; set; } = null!;

    [ForeignKey(nameof(Town))]
    public int TownId { get; set; }

    public virtual Town Town { get; set; } = null!;

    [InverseProperty(nameof(Game.HomeTeam))] // ако използваме Fluent API, няма нужда от този атрибут
    public virtual ICollection<Game> HomeGames { get; set; } = new HashSet<Game>();

    [InverseProperty(nameof(Game.AwayTeam))]
    public virtual ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();

    public virtual ICollection<Player> Players { get; set; } = new HashSet<Player>();
}
