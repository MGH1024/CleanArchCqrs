using FluentValidation;
using Domain.Repositories;

namespace Application.DTOs.Product.Validators;

public class CreateProductValidator : AbstractValidator<CreateProduct>
{
    private readonly IProductRepository _categoryRepository;

    public CreateProductValidator(IProductRepository productRepository)
    {
        _categoryRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        Include(new ProductDtoValidator(_categoryRepository));

        RuleFor(x => x.Code)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}