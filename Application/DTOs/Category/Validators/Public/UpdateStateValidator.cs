using Application.Persistence.Contracts;
using FluentValidation;

namespace Application.DTOs.Category.Validators.Public;

public class UpdateStateValidator : AbstractValidator<UpdateCategory>
{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateStateValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        Include(new StateDtoValidator(_categoryRepository));
    }
}

