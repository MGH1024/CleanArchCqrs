using Domain.Repositories;
using FluentValidation;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{

    public UpdateCategoryCommandValidator()
    {
        RuleFor(a => a.UpdateCategoryDto.Title)
            .NotEmpty()
            .MaximumLength(64);

        RuleFor(x => x.UpdateCategoryDto.Code)
            .GreaterThan(0);
    }
}