using AutoMapper;
using Application.Contracts.Messaging;
using Application.Models.Responses;
using Domain.Entities.Shop;
using Domain.Repositories;

namespace Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.CreateProduct);
        await _unitOfWork.ProductRepository.CreateProductAsync(product);
        await _unitOfWork.Save();
        return new ApiResponse(new List<string> { "create success" });
    }
}