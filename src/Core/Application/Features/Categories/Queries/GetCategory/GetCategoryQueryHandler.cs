using AutoMapper;
using Application.DTOs.Category;
using Application.Contracts.Messaging;
using Application.Exceptions;
using Application.Models.Responses;
using Domain.Repositories;

namespace Application.Features.Categories.Queries.GetCategory;

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
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        if (category is null)
            throw new BadRequestException("category not found");
        
        return new ApiResponse
        {
            Data = _mapper.Map<CategoryDetail>(category),
            Messages = new List<string>{"success"}
        };
    }
}