using AutoMapper;
using Application.Responses;
using Application.Contracts.Messaging;
using Domain.Entities.Shop;
using Domain.Repositories;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.CreateProduct);
        product = await _unitOfWork.ProductRepository.CreateProductAsync(product);
        await _unitOfWork.Save();
        return new BaseCommandResponse
        {
            Id = product.Id,
            Message = "create success",
            Success = true,
        };
    }
}