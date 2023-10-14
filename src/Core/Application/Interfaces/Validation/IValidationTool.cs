using Application.Models.Validation;

namespace Application.Interfaces.Validation
{
    public interface IValidationTool
    {
        Task<ValidationResult> Validate<TValidator>(object data) where TValidator : class, new();
    }
}
