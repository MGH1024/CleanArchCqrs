using Application.Contracts.Messaging;
using Application.DTOs.Product;
using Application.Models.Responses;
using AutoMapper;
using Domain.Repositories;
using MGH.Exceptions;

namespace Application.Features.Product.Queries.GetProduct;

public class GetProductQueryHandler : IQueryHandler<GetProductQuery, ApiResponse>
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
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        if (product is null)
            throw new BadRequestException("product not found");

        return new ApiResponse
        {
           
            Data = _mapper.Map<ProductDetailDto>(product),
            Messages = new List<string>{"success"}
        };
    }
}