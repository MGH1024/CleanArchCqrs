using FluentValidation;

namespace Application.DTOs.Product.Validators;

public class DeleteProductValidator : AbstractValidator<DeleteProductDto>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}