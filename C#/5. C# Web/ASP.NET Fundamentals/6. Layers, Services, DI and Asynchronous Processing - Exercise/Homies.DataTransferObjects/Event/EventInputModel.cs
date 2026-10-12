using System.ComponentModel.DataAnnotations;
using Homies.DataTransferObjects.Type;
using static Homies.GCommon.Constants.EntityValidation.Event;

namespace Homies.DataTransferObjects.Event;

public class EventInputModel
{
    // InputModel: UNTRUSTED Client -> TRUSTED Server - има нужда от Model Validation

    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int TypeId { get; set; }

    // ViewModel вграден в InputModel
    public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
}
