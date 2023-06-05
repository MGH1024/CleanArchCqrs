using FluentValidation;

namespace Application.DTOs.Category.Validators;

public class DeleteCategoryDtoValidator : AbstractValidator<DeleteCategoryDto>
{
    public DeleteCategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}

