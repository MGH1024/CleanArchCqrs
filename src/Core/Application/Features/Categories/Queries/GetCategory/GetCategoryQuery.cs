using Application.Features.Category.Queries.GetCategories;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Validation;
using Application.Models.Responses;
using AutoMapper;
using Domain.ValueObjects;
using MediatR;
using MGH.Exceptions;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryQuery:IRequest<ApiResponse>
{
    public int Id { get; set; }
}

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidationService _validationService;

    public GetCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IValidationService validationService)
    {
        _mapper = mapper ;
        _unitOfWork = unitOfWork ;
        _validationService = validationService;
    }

    public async Task<ApiResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        await _validationService.Validate<GetCategoriesQueryValidator>(request);
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
            throw new BadRequestException("category not found");

        return new ApiResponse(_mapper.Map<CategoryDetailDto>(category),"success");
    }
}