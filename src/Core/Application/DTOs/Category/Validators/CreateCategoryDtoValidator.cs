using FluentValidation;

namespace Application.DTOs.Category.Validators;

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        Include(new CategoryDtoValidator());
    }
}