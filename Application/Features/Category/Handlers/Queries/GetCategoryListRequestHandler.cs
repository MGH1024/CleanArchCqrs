using Application.DTOs.Shop.Category;
using Application.Features.Category.Requests.Queries;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Queries;

public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDetail>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryListRequestHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<List<CategoryDetail>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<List<CategoryDetail>>(categories);
    }
}