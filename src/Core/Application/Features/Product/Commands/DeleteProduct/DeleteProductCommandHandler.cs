﻿using Application.Interfaces.UnitOfWork;
using Application.Models.Responses;
using MediatR;
using MGH.Exceptions;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.DeleteProductDto.Id, cancellationToken);

        if (product is null)
            throw new BadRequestException("product not found");

        _unitOfWork.ProductRepository.DeleteProduct(product, cancellationToken);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
        return new ApiResponse("delete success");
    }
}