using Application.Responses;
using Application.Contracts.Messaging;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : ICommand<BaseCommandResponse>
{
    public DTOs.Product.UpdateProduct  UpdateProduct { get; set; }
}