using NSubstitute;
using Infrastructures.Validation;
using Application.Contracts.Infrastructure.Identity;
using Application.Contracts.Infrastructure.Validation;

namespace TestProject.Base;

public class ValidationServiceFixture
{
    public readonly IUserService _userService;
    private readonly IValidationTool _validationTool;
    public readonly IValidationService _validationService;

    public ValidationServiceFixture()
    {
        _userService = new UserServiceFixture().UserService;
        _validationTool = Substitute.For<FluentValidationTool>();
        _validationService = new ValidationService(_validationTool);
    }
}