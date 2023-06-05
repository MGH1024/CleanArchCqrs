using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommand : ICommand<ApiResponse>
{
    public DTOs.Product.UpdateProductDto  UpdateProductDto { get; set; }
}