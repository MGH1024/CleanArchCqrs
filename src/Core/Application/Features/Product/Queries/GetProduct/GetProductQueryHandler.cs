using Application.Features.Product.Queries.GetProducts;
using Application.Interfaces.UnitOfWork;
using Application.Models.Responses;
using AutoMapper;
using MediatR;
using MGH.Exceptions;

namespace Application.Features.Product.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            throw new BadRequestException("product not found");

        return new ApiResponse(_mapper.Map<ProductDetailDto>(product),"success");
    }
}