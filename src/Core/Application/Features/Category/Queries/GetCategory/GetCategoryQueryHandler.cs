using Application.Contracts.Messaging;
using Application.DTOs.Category;
using Application.Models.Responses;
using AutoMapper;
using Domain.Repositories;
using MGH.Exceptions;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(GetCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category is null)
            throw new BadRequestException("category not found");
        
        return new ApiResponse
        {
            Data = _mapper.Map<CategoryDetailDto>(category),
            Messages = new List<string>{"success"}
        };
    }
}