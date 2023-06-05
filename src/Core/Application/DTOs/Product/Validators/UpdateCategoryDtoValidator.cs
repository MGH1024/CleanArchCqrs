using FluentValidation;

namespace Application.DTOs.Product.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {
        Include(new ProductDtoValidator());
    }
}