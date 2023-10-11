using FluentValidation;

namespace Application.Features.Authentications.Queries.GetUserByEmail;

public class GetUserByEmailValidator:AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailValidator()
    {
        RuleFor(a => a.GetUserByEmailDto.Email)
            .NotEmpty();
    }
}