using AutoMapper;
using Application.Responses;
using Application.DTOs.Category;
using Application.Contracts.Messaging;
using Domain.Repositories;

namespace Application.Features.Categories.Queries.GetCategory;

public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, BaseQueryResponse<CategoryDetail>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseQueryResponse<CategoryDetail>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
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