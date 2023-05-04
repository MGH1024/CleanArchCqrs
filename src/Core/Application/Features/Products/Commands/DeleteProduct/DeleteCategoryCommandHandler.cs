using Application.Responses;
using Application.Contracts.Messaging;
using Application.Contracts.Persistence;
using Application.DTOs.Product.Validators;
using Application.Exceptions;

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
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.DeleteProduct.Id);

        if (category is null)
            throw new BadRequestException("product not found");

        _unitOfWork.CategoryRepository.DeleteCategory(category);
        await _unitOfWork.Save();
        return new BaseCommandResponse
        {
            Success = true,
            Message = "delete success"
        };
    }
}