using FluentValidation;

namespace Application.Features.Product.Queries.GetProduct;

public class GetProductByIdValidator : AbstractValidator<GetProductByIdDto>
{
    public GetProductByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .GreaterThan(0);
    }
}