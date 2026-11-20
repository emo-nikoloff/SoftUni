using System.ComponentModel.DataAnnotations;

using CinemaApp.Data.Common.Models;
using static CinemaApp.Data.Common.EntityValidation.Cinema;

namespace CinemaApp.Data.Models;

public class Cinema : ISoftDeletableEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(LocationNameMaxLength)]
    public string Location { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public virtual ICollection<CinemaMovie> CinemaProjections { get; set; } = new HashSet<CinemaMovie>();
}
