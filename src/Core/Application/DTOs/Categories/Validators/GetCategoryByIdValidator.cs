using FluentValidation;

namespace Application.DTOs.Category.Validators;

public class GetCategoryByIdValidator : AbstractValidator<GetCategoryById>
{
    public GetCategoryByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Not null")
            .GreaterThan(0).WithMessage("must greater than 1");
    }
}

