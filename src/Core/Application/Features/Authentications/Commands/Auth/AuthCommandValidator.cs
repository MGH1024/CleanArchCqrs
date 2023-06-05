using FluentValidation;

namespace Application.Features.Authentications.Commands.Auth;

public class AuthCommandValidator :AbstractValidator<AuthCommand>
{
    public AuthCommandValidator()
    {
        RuleFor(a => a.AuthRequestDto.UserName)
            .NotEmpty()
            .WithMessage("not empty");

        RuleFor(a => a.AuthRequestDto.Password)
            .NotEmpty()
            .WithMessage("not empty");
    }
}