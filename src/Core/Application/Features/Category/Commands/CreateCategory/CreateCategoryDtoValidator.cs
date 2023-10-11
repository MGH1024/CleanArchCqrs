using FluentValidation;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty()
            .MaximumLength(64);

        RuleFor(x => x.Code)
            .GreaterThan(0);
    }
}