using FluentValidation;
using Application.DTOs.Product.Base;

namespace Application.DTOs.Product.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
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
}
