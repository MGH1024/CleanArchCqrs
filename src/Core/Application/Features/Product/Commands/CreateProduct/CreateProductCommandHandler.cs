using Application.Interfaces.UnitOfWork;
using Application.Models.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ApiResponse>
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
        await _unitOfWork.ProductRepository.CreateProductAsync(product, cancellationToken);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
        return new ApiResponse(new List<string> { "create success" });
    }
}