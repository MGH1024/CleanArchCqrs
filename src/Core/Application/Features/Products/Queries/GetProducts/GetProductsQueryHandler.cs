using AutoMapper;
using Application.Responses;
using Application.DTOs.Product;
using Application.Contracts.Messaging;
using Domain.Repositories;

namespace Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, BaseQueryResponse<List<ProductDetail>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseQueryResponse<List<ProductDetail>>> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync();
        return new BaseQueryResponse<List<ProductDetail>>
        {
            Success = true,
            Message = "success",
            Data = _mapper.Map<List<ProductDetail>>(products),
        };
    }
}