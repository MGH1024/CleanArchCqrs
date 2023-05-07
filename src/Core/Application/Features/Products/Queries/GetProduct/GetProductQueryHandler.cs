using AutoMapper;
using Application.Responses;
using Application.DTOs.Product;
using Application.Contracts.Messaging;
using Application.Exceptions;
using Domain.Repositories;

namespace Application.Features.Products.Queries.GetProduct;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, BaseQueryResponse<ProductDetail>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseQueryResponse<ProductDetail>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        if (product is null)
            throw new BadRequestException("product not found");
        return new BaseQueryResponse<ProductDetail>
        {
            Success = true,
            Data = _mapper.Map<ProductDetail>(product),
            Message = "success"
        };
    }
}