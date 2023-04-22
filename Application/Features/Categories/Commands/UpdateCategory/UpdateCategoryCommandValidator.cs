using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? 
                              throw  new ArgumentNullException(nameof(categoryRepository));
        
        RuleFor(a => a.UpdateCategory.Title)
            .NotEmpty().WithMessage("not empty")
            .MaximumLength(64).WithMessage("length error")
            .MustAsync(
                async (title, token) =>
                    await _categoryRepository.IsCategoryRegistered(title))
            .WithMessage("title is repetitive");

        RuleFor(x => x.UpdateCategory.Code)
            .GreaterThan(0).WithMessage("must greater than 0");
    }
}