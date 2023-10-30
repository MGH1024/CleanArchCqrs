using FluentValidation;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(a => a.CreateCategory.Title)
            .NotEmpty()
            .MaximumLength(64);

        RuleFor(x => x.CreateCategory.Code)
            .GreaterThan(0);
    }
}