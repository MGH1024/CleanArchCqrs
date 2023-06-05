using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Product.Queries.GetProduct;

public class GetProductQuery:IQuery<ApiResponse>
{
    public int Id { get; set; }
}