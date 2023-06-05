using FluentValidation;

namespace Application.Features.Authentications.Queries.GetUserByToken;

public class GetUserByTokenValidator:AbstractValidator<GetUserByTokenQuery>
{
    public GetUserByTokenValidator()
    {
        RuleFor(a => a.GetUserByTokenDto.Token)
            .NotNull().WithMessage("token can't be null")
            .NotEmpty().WithMessage("token can't be empty");
    }
}