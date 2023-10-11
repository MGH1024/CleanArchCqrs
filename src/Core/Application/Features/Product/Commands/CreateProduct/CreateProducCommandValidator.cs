using Domain.Repositories;
using FluentValidation;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository 
                              ?? throw new ArgumentNullException(nameof(productRepository));
        
        RuleFor(a => a.CreateProductDto.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error")
            .MustAsync(
                async (title, token) =>
                    await _productRepository.IsProductRegisteredAsync(title, new CancellationToken()))
            .WithMessage("title is repetitive");

        RuleFor(x => x.CreateProductDto.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}