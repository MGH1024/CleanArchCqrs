using Domain.Repositories;
using FluentValidation;

namespace Application.DTOs.Category.Validators;

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        Include(new CategoryDtoValidator());
    }
}

