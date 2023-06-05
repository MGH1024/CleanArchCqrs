using Application.Contracts.Messaging;
using Application.Exceptions;
using Application.Models.Responses;
using Domain.Repositories;

namespace Application.Features.Product.Commands.UpdateProduct;

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
            .GetByIdAsync(request.UpdateProductDto.Id);

        if (product is null)
            throw new BadRequestException("product not found");

        product.Code = request.UpdateProductDto.Code;
        product.Title = request.UpdateProductDto.Title;
        product.Quantity = request.UpdateProductDto.Quantity;
        product.Description = request.UpdateProductDto.Description;
        product.CategoryId = request.UpdateProductDto.CategoryId;

        _unitOfWork.ProductRepository
            .UpdateProduct(product);

        await _unitOfWork.Save();

        return new ApiResponse()
        {
            Messages = new List<string> { "update success" }
        };
    }
}