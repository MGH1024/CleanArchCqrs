using FluentValidation;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.DeleteProductDto.Id)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}