using FluentValidation;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
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
    }
}