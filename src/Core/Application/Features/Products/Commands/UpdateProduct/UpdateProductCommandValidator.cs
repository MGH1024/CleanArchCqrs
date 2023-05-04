using FluentValidation;
using Application.Contracts.Persistence;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository ??
                             throw new ArgumentNullException(nameof(productRepository));

        RuleFor(a => a.UpdateProduct.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error")
            .MustAsync(
                async (title, token) =>
                    await _productRepository.IsProductRegistered(title))
            .WithMessage("title is repetitive");

        RuleFor(x => x.UpdateProduct.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
        
        RuleFor(x => x.UpdateProduct.Quantity)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}