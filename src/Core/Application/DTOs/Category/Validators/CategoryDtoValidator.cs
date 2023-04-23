using Application.Contracts.Persistence;
using FluentValidation;
using Application.DTOs.Category.Base;

namespace Application.DTOs.Category.Validators
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(a => a.Title)
                .NotEmpty().WithMessage("not empty")
                .MaximumLength(64).WithMessage("length error")
                .MustAsync(
                    async (title, token) =>
                    await _categoryRepository.IsCategoryRegistered(title))
                .WithMessage("title is repetitive");

            RuleFor(x => x.Code)
                .GreaterThan(0).WithMessage("must greater than 0");
        }
    }
}
