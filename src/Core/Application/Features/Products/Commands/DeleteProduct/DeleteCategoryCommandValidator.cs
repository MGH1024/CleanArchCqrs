using FluentValidation;

namespace Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.DeleteProduct.Id)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}