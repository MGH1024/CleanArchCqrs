using Domain.Repositories;
using FluentValidation;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(a => a.CreateCategory.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error");

        RuleFor(x => x.CreateCategory.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}