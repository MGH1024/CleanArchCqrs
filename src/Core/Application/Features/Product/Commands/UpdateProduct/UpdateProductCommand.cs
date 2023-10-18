using Application.Models.Responses;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<ApiResponse>
{
    public UpdateProductDto  UpdateProductDto { get; set; }
}