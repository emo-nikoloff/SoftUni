using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data.Models;

[PrimaryKey(nameof(HelperId), nameof(EventId))]
public class EventParticipant
{
    [Required]
    [ForeignKey(nameof(Helper))]
    public string HelperId { get; set; } = null!;

    public virtual IdentityUser Helper { get; set; } = null!;

    [ForeignKey(nameof(Event))]
    public int EventId { get; set; }

    public virtual Event Event { get; set; } = null!;
}
