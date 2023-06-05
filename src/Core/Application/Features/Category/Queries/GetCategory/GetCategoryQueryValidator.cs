using FluentValidation;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryQueryValidator:AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Not null")
            .GreaterThan(0).WithMessage("must greater than 1");
    }
}