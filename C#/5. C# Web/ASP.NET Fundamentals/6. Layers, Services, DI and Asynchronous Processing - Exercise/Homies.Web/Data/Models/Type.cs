using System.ComponentModel.DataAnnotations;

using static Homies.Web.Common.EntityValidation.Type;

namespace Homies.Web.Data.Models;

public class Type
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
