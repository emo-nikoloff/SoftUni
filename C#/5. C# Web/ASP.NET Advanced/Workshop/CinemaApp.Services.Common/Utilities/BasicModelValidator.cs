using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Services.Common.Utilities;

public class BasicModelValidator
{
    private readonly IList<ValidationResult> _validationResults;

    public BasicModelValidator()
    {
        _validationResults = new List<ValidationResult>();
    }

    public IReadOnlyCollection<ValidationResult> ValidationResults
        => _validationResults.AsReadOnly();

    public bool IsValid(object model)
    {
        ValidationContext validationContext = new(model);
        List<ValidationResult> validationResults = new();

        return Validator.TryValidateObject(model, validationContext, _validationResults, true);
    }

    public static bool IsValid(object model, List<ValidationResult> validationResults)
    {
        ValidationContext validationContext = new(model);

        return Validator.TryValidateObject(model, validationContext, validationResults, true);
    }
}
