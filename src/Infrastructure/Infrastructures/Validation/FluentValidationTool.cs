using Application.Interfaces.Validation;
using FluentValidation;
using Application.Models.Validation;
using MGH.Exceptions.Models;

namespace Infrastructures.Validation;

public class FluentValidationTool : IValidationTool
{
    public async Task<ValidationResult> Validate<TValidator>(object data)
        where TValidator : class, new()
    {
        TValidator validator = new();

        if (validator is not IValidator)
            throw new NotSupportedException();

        IEnumerable<ValidationError> errors = Array.Empty<ValidationError>();
        var context = new ValidationContext<object>(data);

        var validationResult = new FluentValidation.Results.ValidationResult();

        try
        {
            validationResult = await ((IValidator)validator).ValidateAsync(context);
            if (!validationResult.Errors.Any())
                return new ValidationResult(true, errors);
            errors = validationResult.Errors.Select(x =>
                new ValidationError(x.PropertyName, x.ErrorMessage));
        }
        catch (Exception)
        {
            if (validationResult.Errors.Count == 0)
                errors = new List<ValidationError>() { new ValidationError("dto", "dto is null") };
        }

        return new ValidationResult(false, errors);
    }
}