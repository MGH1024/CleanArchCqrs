using FluentValidation;
using Domain.Repositories;

namespace Application.DTOs.Product.Validators;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{

    public CreateProductDtoValidator(IProductRepository productRepository)
    {
        Include(new ProductDtoValidator());

        RuleFor(x => x.Code)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}