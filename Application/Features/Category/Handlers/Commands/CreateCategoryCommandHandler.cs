﻿using MediatR;
using AutoMapper;
using Application.Persistence.Contracts;
using Application.Features.Category.Requests.Commands;



namespace Application.Features.Category.Handlers.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category =  _mapper.Map<Domain.Shop.Category>(request.CreateCategory);
        category = await _categoryRepository.CreateCategoryAsync(category);
        return category.Id;
    }
}