using FluentValidation;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(a => a.Title)
            .NotEmpty()
            .MaximumLength(64);

        RuleFor(x => x.Code)
            .GreaterThan(0);
    }
}