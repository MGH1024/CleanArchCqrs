using Application.Models.Responses;
using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommand:IRequest<ApiResponse>
{
    public DeleteProductDto DeleteProductDto { get; set; }
}