using Application.DTOs.Category.Base;
using FluentValidation;

namespace Application.DTOs.Category.Validators
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("must greater than zero");
            
            RuleFor(a => a.Title)
                .NotEmpty().WithMessage("not empty")
                .MaximumLength(64).WithMessage("length error");
                
                // .MustAsync(
                //     async (title, token) =>
                //     await _categoryRepository.IsCategoryRegistered(title))
                // .WithMessage("title is repetitive");

            RuleFor(x => x.Code)
                .GreaterThan(0).WithMessage("must greater than 0");
        }
    }
}
