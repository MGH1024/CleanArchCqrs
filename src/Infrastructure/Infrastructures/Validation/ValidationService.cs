using Application.Contracts.Infrastructure.Validation;
using Application.Exceptions.Validation;

namespace Infrastructures.Validation
{
    public class ValidationService : IValidationService
    {
        private readonly IValidationTool _validationTool;

        public ValidationService(IValidationTool validationTool)
        {
            _validationTool = validationTool;
        }
        
        public async Task Validate<TValidator>(object data)
            where TValidator : class, new()
        {
            var validationResult = await _validationTool.Validate<TValidator>(data);
            if (!validationResult.IsValid)
                throw new CustomValidationException(validationResult.Errors);
        }
    }
}
