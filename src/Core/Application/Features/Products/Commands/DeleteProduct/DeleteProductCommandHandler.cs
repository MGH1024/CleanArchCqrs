using Application.Responses;
using Application.Contracts.Messaging;
using Application.DTOs.Product.Validators;
using Application.Exceptions;
using Domain.Repositories;

namespace Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseCommandResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.DeleteProduct.Id);

        if (product is null)
            throw new BadRequestException("product not found");

        _unitOfWork.ProductRepository.DeleteProduct(product);
        await _unitOfWork.Save();
        return new BaseCommandResponse
        {
            Success = true,
            Message = "delete success"
        };
    }
}