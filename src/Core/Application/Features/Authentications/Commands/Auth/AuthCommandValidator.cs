using FluentValidation;

namespace Application.Features.Authentications.Commands.Auth;

public class AuthCommandValidator :AbstractValidator<AuthCommand>
{
    public AuthCommandValidator()
    {
        RuleFor(a => a.AuthRequest.UserName)
            .NotEmpty()
            .WithMessage("not empty");

        RuleFor(a => a.AuthRequest.Password)
            .NotEmpty()
            .WithMessage("not empty");
    }
}