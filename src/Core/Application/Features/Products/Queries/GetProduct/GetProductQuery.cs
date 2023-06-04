using Application.DTOs.Product;
using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Products.Queries.GetProduct;

public class GetProductQuery:IQuery<ApiResponse>
{
    public int Id { get; set; }
}