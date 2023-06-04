using Application.Contracts.Messaging;
using Application.Models.Responses;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : ICommand<ApiResponse>
{
    public DTOs.Product.UpdateProduct  UpdateProduct { get; set; }
}