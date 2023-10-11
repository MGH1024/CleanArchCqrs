using Domain.Repositories;
using FluentValidation;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository ??
                             throw new ArgumentNullException(nameof(productRepository));

        RuleFor(a => a.UpdateProductDto.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error")
            .MustAsync(
                async (title, token) =>
                    await _productRepository.IsProductRegisteredAsync(title, new CancellationToken()))
            .WithMessage("title is repetitive");

        RuleFor(x => x.UpdateProductDto.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
        
        RuleFor(x => x.UpdateProductDto.Quantity)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}