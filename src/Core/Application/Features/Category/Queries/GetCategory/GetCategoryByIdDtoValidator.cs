using FluentValidation;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryByIdDtoValidator : AbstractValidator<GetCategoryByIdDto>
{
    public GetCategoryByIdDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}

