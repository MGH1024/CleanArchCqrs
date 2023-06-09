using FluentValidation;

namespace Application.DTOs.Category.Validators;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error");

        RuleFor(x => x.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}