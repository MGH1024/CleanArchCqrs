using Application.Features.Security.Commands.Login;
using FluentValidation;

namespace Application.Features.Security.Commands.RegisterUser;

public class RegisterUserCommandValidator :AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(a => a.RegisterUserDto.FirstName)
            .NotEmpty()
            .MaximumLength(128);
        
        RuleFor(a => a.RegisterUserDto.LastName)
            .NotEmpty()
            .MaximumLength(128);
        
        RuleFor(a => a.RegisterUserDto.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(a => a.RegisterUserDto.Password)
            .NotEmpty();
        
        RuleFor(a => a.RegisterUserDto.Gender)
            .NotNull()
            .IsInEnum();
    }
}