using Domain.Repositories;
using FluentValidation;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{

    public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        RuleFor(a => a.UpdateCategoryDto.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error");

        RuleFor(x => x.UpdateCategoryDto.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}