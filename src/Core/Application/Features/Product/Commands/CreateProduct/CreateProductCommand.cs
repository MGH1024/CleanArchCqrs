using Application.Models.Responses;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ApiResponse>
{
    public CreateProductDto CreateProductDto { get; set; }
}