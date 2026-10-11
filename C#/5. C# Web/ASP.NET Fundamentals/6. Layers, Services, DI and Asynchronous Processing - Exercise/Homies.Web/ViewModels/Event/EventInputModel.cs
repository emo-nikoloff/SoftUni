using System.ComponentModel.DataAnnotations;
using Homies.Web.ViewModels.Type;
using static Homies.Web.Common.EntityValidation.Event;

namespace Homies.Web.ViewModels.Event;

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
    public IEnumerable<TypeDropdownViewModel> Types { get; set; } = new List<TypeDropdownViewModel>();
}
