using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static EventManager.Common.EntityValidation.Event;

namespace EventManager.Data.Models;

public class Event
{
    /* Тук се прилага Domain Model Validation:
     * Покриваме DB Schema валидации само
     * Използваме EF Core Data Attributes + Fluent API */

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int MaxParticipants { get; set; }

    [ForeignKey(nameof(Category))]
    public int? CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

}
