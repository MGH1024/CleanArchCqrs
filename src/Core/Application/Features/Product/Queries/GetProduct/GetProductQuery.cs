using Application.Models.Responses;
using MediatR;

namespace Application.Features.Product.Queries.GetProduct;

public class GetProductQuery:IRequest<ApiResponse>
{
    public int Id { get; set; }
}