using Application.Contracts.Messaging;
using Application.Models.Responses;
using Domain.Repositories;
using MGH.Exceptions;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.DeleteProductDto.Id);

        if (product is null)
            throw new BadRequestException("product not found");

        _unitOfWork.ProductRepository.DeleteProduct(product);
        await _unitOfWork.Save(cancellationToken);
        return new ApiResponse
        {
            Messages = new List<string>{"delete success"}
        };
    }
}