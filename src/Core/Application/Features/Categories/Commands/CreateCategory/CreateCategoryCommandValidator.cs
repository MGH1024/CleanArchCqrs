using Domain.Repositories;
using FluentValidation;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository 
                              ?? throw new ArgumentNullException(nameof(categoryRepository));
        
        RuleFor(a => a.CreateCategory.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error")
            .MustAsync(
                async (title, token) =>
                    await _categoryRepository.IsCategoryRegistered(title))
            .WithMessage("title is repetitive");

        RuleFor(x => x.CreateCategory.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}