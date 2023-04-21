using FluentValidation;
using Application.Persistence.Contracts;

namespace Application.DTOs.Category.Validators.Public;

public class CreateStateValidator : AbstractValidator<CreateCategory>
{
    private readonly ICategoryRepository _categoryRepository;
    public CreateStateValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository=categoryRepository;

        Include(new StateDtoValidator(_categoryRepository));

        RuleFor(x => x.Code)
            .GreaterThan(0).WithMessage("must greater than zero");
    }
}

