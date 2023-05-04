using Application.Responses;
using Application.DTOs.Product;
using Application.Contracts.Messaging;

namespace Application.Features.Products.Queries.GetProduct;

public class GetProductQuery:IQuery<BaseQueryResponse<ProductDetail>>
{
    public int Id { get; set; }
}