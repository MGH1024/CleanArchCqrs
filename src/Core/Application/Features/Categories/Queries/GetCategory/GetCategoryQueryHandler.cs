using Application.Contracts.Messaging;
using Application.Contracts.Persistence;
using Application.DTOs.Category;
using Application.Responses;
using AutoMapper;

namespace Application.Features.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, BaseQueryResponse<CategoryDetail>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<BaseQueryResponse<CategoryDetail>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if(category is null)
            return new BaseQueryResponse<CategoryDetail>
            {
                Success = false,
                Message = "category not found"
            };
        return new BaseQueryResponse<CategoryDetail>
        {
            Success = true,
            Data = _mapper.Map<CategoryDetail>(category),
            Message = "success"
        };
    }
}