using FluentValidation;

namespace Application.DTOs.Product.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {
        RuleFor(a => a.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error");
        // .MustAsync(
        //     async (title, token) =>
        //     await _productRepository.IsProductRegistered(title))
        // .WithMessage("title is repetitive");

        RuleFor(x => x.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
            
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("must greater than 0");
            
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}