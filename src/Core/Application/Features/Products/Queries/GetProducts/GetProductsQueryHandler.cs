using AutoMapper;
using Application.DTOs.Product;
using Application.Contracts.Messaging;
using Application.Models.Responses;
using Domain.Repositories;

namespace Application.Features.Products.Queries.GetProducts;

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(GetProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync();
        return new ApiResponse
        {
            
            Messages = new List<string>{"success"},
            Data = _mapper.Map<List<ProductDetail>>(products),
        };
    }
}