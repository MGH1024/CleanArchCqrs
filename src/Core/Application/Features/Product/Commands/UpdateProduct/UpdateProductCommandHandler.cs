using Application.Contracts.Messaging;
using Application.Interfaces;
using Application.Interfaces.UnitOfWork;
using Application.Models.Responses;
using Domain.Repositories;
using MGH.Exceptions;

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
            .GetByIdAsync(request.UpdateProductDto.Id, cancellationToken);

        if (product is null)
            throw new BadRequestException("product not found");

        product.Code = request.UpdateProductDto.Code;
        product.Title = request.UpdateProductDto.Title;
        product.Quantity = request.UpdateProductDto.Quantity;
        product.Description = request.UpdateProductDto.Description;
        product.CategoryId = request.UpdateProductDto.CategoryId;

        _unitOfWork.ProductRepository
            .UpdateProduct(product, cancellationToken);

        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return new ApiResponse("update success");
    }
}