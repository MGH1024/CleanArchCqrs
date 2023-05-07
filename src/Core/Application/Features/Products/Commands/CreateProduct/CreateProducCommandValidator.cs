using FluentValidation;
using Domain.Repositories;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository 
                              ?? throw new ArgumentNullException(nameof(productRepository));
        
        RuleFor(a => a.CreateProduct.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error")
            .MustAsync(
                async (title, token) =>
                    await _productRepository.IsProductRegistered(title))
            .WithMessage("title is repetitive");

        RuleFor(x => x.CreateProduct.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}