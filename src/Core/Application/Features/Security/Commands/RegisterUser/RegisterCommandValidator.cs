using Application.Features.Security.Commands.Login;
using FluentValidation;

namespace Application.Features.Security.Commands.RegisterUser;

public class RegisterCommandValidator :AbstractValidator<LoginCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(a => a.UserLoginDto.Email)
            .NotEmpty();

        RuleFor(a => a.UserLoginDto.Password)
            .NotEmpty();
    }
}