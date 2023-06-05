using Application.Contracts.Messaging;
using Application.DTOs.Product;
using Application.Models.Responses;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommand:ICommand<ApiResponse>
{
    public DeleteProductDto DeleteProductDto { get; set; }
}