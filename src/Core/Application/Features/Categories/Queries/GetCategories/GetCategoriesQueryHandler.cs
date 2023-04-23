using Application.Contracts.Messaging;
using Application.Contracts.Persistence;
using Application.DTOs.Category;
using Application.Responses;
using AutoMapper;

namespace Application.Features.Categories.Queries.GetCategories;

public class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, BaseQueryResponse<List<CategoryDetail>>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<BaseQueryResponse<List<CategoryDetail>>> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();
        return new BaseQueryResponse<List<CategoryDetail>>
        {
            Success = true,
            Data = _mapper.Map<List<CategoryDetail>>(categories),
            Message = "success"
        };
    }
}