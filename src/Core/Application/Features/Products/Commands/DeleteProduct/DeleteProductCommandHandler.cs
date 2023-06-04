using Application.Contracts.Messaging;
using Application.DTOs.Product.Validators;
using Application.Exceptions;
using Application.Models.Responses;
using Domain.Repositories;

namespace Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.DeleteProduct.Id);

        if (product is null)
            throw new BadRequestException("product not found");

        _unitOfWork.ProductRepository.DeleteProduct(product);
        await _unitOfWork.Save();
        return new ApiResponse
        {
            Messages = new List<string>{"delete success"}
        };
    }
}