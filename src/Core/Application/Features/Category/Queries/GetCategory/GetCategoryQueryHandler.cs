using Application.Features.Category.Queries.GetCategories;
using Application.Interfaces.UnitOfWork;
using Application.Models.Responses;
using AutoMapper;
using MediatR;
using MGH.Exceptions;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
            throw new BadRequestException("category not found");

        return new ApiResponse(_mapper.Map<CategoryDetailDto>(category),"success");
    }
}