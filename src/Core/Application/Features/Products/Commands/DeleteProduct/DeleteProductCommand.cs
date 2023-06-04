using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand:ICommand<ApiResponse>
{
    public DTOs.Product.DeleteProduct DeleteProduct { get; set; }
}