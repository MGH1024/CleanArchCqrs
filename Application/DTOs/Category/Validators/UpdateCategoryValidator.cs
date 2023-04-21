using FluentValidation;
using Application.Persistence.Contracts;

namespace Application.DTOs.Category.Validators;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategory>
{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateCategoryValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        Include(new CategoryDtoValidator(_categoryRepository));
    }
}

