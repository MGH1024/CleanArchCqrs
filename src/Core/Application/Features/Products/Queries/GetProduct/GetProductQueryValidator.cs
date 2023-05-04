using FluentValidation;

namespace Application.Features.Products.Queries.GetProduct;

public class GetProductQueryValidator:AbstractValidator<GetProductQuery>
{
    public GetProductQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Not null")
            .GreaterThan(0).WithMessage("must greater than 1");
    }
}