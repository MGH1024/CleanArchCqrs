using Application.Responses;
using Application.Contracts.Messaging;
using Application.Contracts.Persistence;
using Application.Exceptions;

namespace Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;


    public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
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

        return new BaseCommandResponse
        {
            Success = true,
            Message = "update success",
            Id = product.Id
        };
    }
}