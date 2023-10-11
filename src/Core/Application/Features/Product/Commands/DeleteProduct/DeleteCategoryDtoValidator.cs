using FluentValidation;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductValidator : AbstractValidator<DeleteProductDto>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}