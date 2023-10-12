using FluentValidation;

namespace Application.Features.Security.Commands.Login;

public class LoginCommandValidator :AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(a => a.UserLoginDto.Email)
            .NotEmpty();

        RuleFor(a => a.UserLoginDto.Password)
            .NotEmpty();
    }
}