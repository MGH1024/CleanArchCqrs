using Domain.Repositories;
using FluentValidation;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{

    public CreateProductDtoValidator(IProductRepository productRepository)
    {
        RuleFor(a => a.Title)
            .NotEmpty()
            .MaximumLength(64);

        RuleFor(x => x.Code)
            .GreaterThan(0);
            
        RuleFor(x => x.Quantity)
            .GreaterThan(0);
            
        RuleFor(x => x.CategoryId)
            .GreaterThan(0);

        RuleFor(x => x.Code)
            .GreaterThan(0);
    }
}