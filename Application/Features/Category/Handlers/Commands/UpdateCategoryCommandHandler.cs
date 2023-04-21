using Application.DTOs.Category.Validators;
using Application.Exceptions;
using Application.Features.Category.Requests.Commands;
using Application.Persistence.Contracts;
using AutoMapper;
using MediatR;

namespace Application.Features.Category.Handlers.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryValidator(_categoryRepository);
        var validationResult = await validator
            .ValidateAsync(request.UpdateCategory, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);
        
        var category = await _categoryRepository.GetByIdAsync(request.UpdateCategory.Id);
        
        if (category is null)
            throw new NotFoundException(nameof(Domain.Shop.Category),request.UpdateCategory.Id);
        
        await _categoryRepository.UpdateCategoryAsync(category);
        return Unit.Value;
    }
}