﻿using Application.Interfaces.UnitOfWork;
using Application.Models.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Queries.GetCategories;

public class GetCategoriesQuery :IRequest<ApiResponse>
{
    public string IpAddress { get; set; }
}

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoriesQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
        return new ApiResponse(_mapper.Map<List<CategoryDetailDto>>(categories),"success");
    }
}