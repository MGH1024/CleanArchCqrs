using FluentValidation;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator:AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.DeleteCategoryDto.Id)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}