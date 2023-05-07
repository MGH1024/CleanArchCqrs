using FluentValidation;
using Domain.Repositories;

namespace Application.DTOs.Product.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProduct>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

        Include(new ProductDtoValidator(_productRepository));
    }
}