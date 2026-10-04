using System.ComponentModel.DataAnnotations;

using EventManager.ViewModels.Categories;
using static EventManager.Common.EntityValidation.Event;

namespace EventManager.ViewModels.Events;

public class EventInputModel : IValidatableObject
{
    /* Model Validation е задължителен тук
     * Потокът на данни е от UNTRUSTED Client към TRUSTED Server */

    // Поток на данни - Client -> Server
    [Required(ErrorMessage = "Event title is required.")]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; } = null!;

    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Range(MaxParticipantsMinValue, MaxParticipantsMaxValue)]
    public int MaxParticipants { get; set; }

    public int CategoryId { get; set; }
    // ---

    // Поток на данни - Server -> Client
    public IEnumerable<CategoryDropdownViewModel> Categories { get; set; } = new List<CategoryDropdownViewModel>();
    // ---

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (StartDate > EndDate)
        {
            yield return new ValidationResult(
                "Start date must be earlier than or equal to the end date.",
                new[] { nameof(StartDate), nameof(EndDate) });
        }
    }
}
