using Application.Contracts.Messaging;
using Application.Models.Responses;
using AutoMapper;
using Domain.Repositories;

namespace Application.Features.Category.Queries.GetCategories;

public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoriesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
        return new ApiResponse
        {
            Data = _mapper.Map<List<CategoryDetailDto>>(categories),
            Messages = new List<string>{"success"}
        };
    }
}