using Application.Responses;
using Application.Contracts.Messaging;

namespace Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommand:ICommand<BaseCommandResponse>
{
    public DTOs.Product.DeleteProduct DeleteProduct { get; set; }
}