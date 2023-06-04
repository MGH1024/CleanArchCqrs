namespace Application.Models.Validation;

public class ValidationResult
{
    public ValidationResult(bool isValid, IEnumerable<ValidationError> errors)
    {
        IsValid = isValid;
        Errors = errors;
    }

    public bool IsValid { get; set; }
    public IEnumerable<ValidationError> Errors { get; set; }
}