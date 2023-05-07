using Application.Contracts.Messaging;
using Application.DTOs.Category;
using Application.Responses;
using AutoMapper;
using Domain.Repositories;

namespace Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, BaseQueryResponse<List<CategoryDetail>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoriesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseQueryResponse<List<CategoryDetail>>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
        return new BaseQueryResponse<List<CategoryDetail>>
        {
            Success = true,
            Data = _mapper.Map<List<CategoryDetail>>(categories),
            Message = "success"
        };
    }
}