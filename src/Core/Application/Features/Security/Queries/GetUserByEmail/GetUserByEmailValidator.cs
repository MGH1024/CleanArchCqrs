using FluentValidation;

namespace Application.Features.Security.Queries.GetUserByEmail;

public class GetUserByEmailValidator:AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailValidator()
    {
        RuleFor(a => a.GetUserByEmailDto.Email)
            .NotEmpty();
    }
}