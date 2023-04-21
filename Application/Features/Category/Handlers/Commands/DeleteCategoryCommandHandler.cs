using Application.DTOs.Category;
using MediatR;
using Application.Exceptions;
using Application.Persistence.Contracts;
using Application.DTOs.Category.Validators;
using Application.Features.Category.Requests.Commands;

namespace Application.Features.Category.Handlers.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCategoryValidator();
        var validationResult = await validator
            .ValidateAsync(request.DeleteCategory, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var category = await _categoryRepository.GetByIdAsync(request.DeleteCategory.Id);

        if (category is null)
            throw new NotFoundException(nameof(Domain.Shop.Category),request.DeleteCategory.Id);
        
        
        await _categoryRepository.DeleteCategoryAsync(category);
        return Unit.Value;
    }
}