using Application.DTOs.Categories;
using FluentValidation;
using Domain.Repositories;

namespace Application.DTOs.Category.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategory>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));

        Include(new CategoryDtoValidator(_categoryRepository));

        RuleFor(x => x.Code)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}