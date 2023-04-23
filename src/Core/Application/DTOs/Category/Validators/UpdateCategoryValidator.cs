using FluentValidation;
using Application.Contracts.Persistence;

namespace Application.DTOs.Category.Validators;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategory>
{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateCategoryValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw  new ArgumentNullException(nameof(categoryRepository));

        Include(new CategoryDtoValidator(_categoryRepository));
    }
}

