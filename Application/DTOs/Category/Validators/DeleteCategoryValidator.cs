using FluentValidation;
using Application.Persistence.Contracts;

namespace Application.DTOs.Category.Validators;

public class DeleteCategoryValidator : AbstractValidator<DeleteCategory>
{
    public DeleteCategoryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}

