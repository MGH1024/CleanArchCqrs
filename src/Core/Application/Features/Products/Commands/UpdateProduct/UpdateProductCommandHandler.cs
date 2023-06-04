using Application.Contracts.Messaging;
using Application.Exceptions;
using Application.Models.Responses;
using Domain.Repositories;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;


    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork
            .ProductRepository
            .GetByIdAsync(request.UpdateProduct.Id);

        if (product is null)
            throw new BadRequestException("product not found");

        product.Code = request.UpdateProduct.Code;
        product.Title = request.UpdateProduct.Title;
        product.Quantity = request.UpdateProduct.Quantity;
        product.Description = request.UpdateProduct.Description;
        product.CategoryId = request.UpdateProduct.CategoryId;

        _unitOfWork.ProductRepository
            .UpdateProduct(product);

        await _unitOfWork.Save();

        return new ApiResponse()
        {
            Messages = new List<string> { "update success" }
        };
    }
}