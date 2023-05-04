using Application.Responses;
using Application.DTOs.Product;
using Application.Contracts.Messaging;

namespace Application.Features.Products.Queries.GetProducts;

public class GetProductsQuery :IQuery<BaseQueryResponse<List<ProductDetail>>>
{
    
}