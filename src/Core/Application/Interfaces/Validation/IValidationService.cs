namespace Application.Interfaces.Validation
{
    public interface IValidationService
    {
        Task Validate<TValidator>(object data) where TValidator : class, new();
    }
}