using FluentValidation;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryDtoValidator : AbstractValidator<DeleteCategoryDto>
{
    public DeleteCategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}

