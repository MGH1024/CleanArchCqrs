using MediatR;
using AutoMapper;
using Application.DTOs.Category;
using Application.Persistence.Contracts;
using Application.Features.Category.Requests.Queries;
using Application.Responses;

namespace Application.Features.Category.Handlers.Queries;

public class
    GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, BaseQueryResponse<List<CategoryDetail>>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryListRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<BaseQueryResponse<List<CategoryDetail>>> Handle(GetCategoryListRequest request,
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