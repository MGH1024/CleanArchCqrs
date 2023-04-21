using FluentValidation;

namespace Application.DTOs.Category.Validators.Public;

public class GetStateByIdValidator : AbstractValidator<GetCategoryById>
{
    public GetStateByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Not null")
            .GreaterThan(0).WithMessage("must greater than 1");
    }
}

