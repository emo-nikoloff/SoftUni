using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

using static Homies.GCommon.Constants.EntityValidation.Event;

namespace Homies.Data.Models;

public class Event
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Organiser))]
    public string OrganiserId { get; set; } = null!;

    public virtual IdentityUser Organiser { get; set; } = null!;

    [Column(TypeName = DateTimeSqlType)]
    public DateTime CreatedOn { get; set; }

    [Column(TypeName = DateTimeSqlType)]
    public DateTime Start { get; set; }

    [Column(TypeName = DateTimeSqlType)]
    public DateTime End { get; set; }

    [ForeignKey(nameof(Type))]
    public int TypeId { get; set; }

    public virtual Type Type { get; set; } = null!;

    public virtual ICollection<EventParticipant> Participants { get; set; } = new List<EventParticipant>();
}
