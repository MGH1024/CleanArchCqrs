using FluentValidation;

namespace Application.DTOs.Category.Validators;

public class GetCategoryByIdDtoValidator : AbstractValidator<GetCategoryByIdDto>
{
    public GetCategoryByIdDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Not null")
            .GreaterThan(0).WithMessage("must greater than 1");
    }
}

