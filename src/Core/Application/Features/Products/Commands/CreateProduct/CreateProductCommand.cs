using Application.Responses;
using Application.Contracts.Messaging;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : ICommand<BaseCommandResponse>
{
    public DTOs.Product.CreateProduct CreateProduct { get; set; }
}