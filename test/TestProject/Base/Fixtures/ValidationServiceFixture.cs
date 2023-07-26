using NSubstitute;
using Infrastructures.Validation;
using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Infrastructure.Validation;

namespace TestProject.Base.Fixtures;

public class ValidationServiceFixture
{
    public readonly IUserService UserService;
    public readonly IValidationService ValidationService;


    public ValidationServiceFixture()
    {
        UserService = new UserServiceFixture().UserService;
        IValidationTool validationTool = Substitute.For<FluentValidationTool>();
        ValidationService = new ValidationService(validationTool);
    }
}