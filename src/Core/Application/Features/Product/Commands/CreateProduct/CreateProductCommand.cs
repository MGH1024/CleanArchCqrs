using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : ICommand<ApiResponse>
{
    public CreateProductDto CreateProductDto { get; set; }
}