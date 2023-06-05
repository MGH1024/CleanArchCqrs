using Application.Contracts.Messaging;
using Application.Models.Responses;
using AutoMapper;
using Domain.Repositories;

namespace Application.Features.Product.Commands.CreateProduct;

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
        var product = _mapper.Map<Domain.Entities.Shop.Product>(request.CreateProductDto);
        await _unitOfWork.ProductRepository.CreateProductAsync(product);
        await _unitOfWork.Save();
        return new ApiResponse(new List<string> { "create success" });
    }
}