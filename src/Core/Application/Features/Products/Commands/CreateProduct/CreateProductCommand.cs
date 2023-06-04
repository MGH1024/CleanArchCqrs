using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : ICommand<ApiResponse>
{
    public DTOs.Product.CreateProduct CreateProduct { get; set; }
}