using FluentValidation;

namespace Application.Features.Product.Queries.GetProducts;

public class GetProductsvalidator:AbstractValidator<GetProductsQuery>
{
    
    public GetProductsvalidator()
    {
    }
}