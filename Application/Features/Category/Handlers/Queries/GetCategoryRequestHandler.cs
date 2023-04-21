using MediatR;
using AutoMapper;
using Application.Responses;
using Application.DTOs.Category;
using Application.Contracts.Persistence;
using Application.Features.Category.Requests.Queries;

namespace Application.Features.Category.Handlers.Queries;

public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, BaseQueryResponse<CategoryDetail>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<BaseQueryResponse<CategoryDetail>> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        return new BaseQueryResponse<CategoryDetail>
        {
            Success = true,
            Data = _mapper.Map<CategoryDetail>(category),
            Message = "success"
        };
    }
}