using MediatR;
using Application.Responses;
using Application.Contracts.Persistence;
using Application.DTOs.Category.Validators;
using Application.Features.Category.Requests.Commands;

namespace Application.Features.Category.Handlers.Commands;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<BaseCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCategoryValidator();
        var validationResult = await validator
            .ValidateAsync(request.DeleteCategory, cancellationToken);
        if (!validationResult.IsValid)
            return new BaseCommandResponse
            {
                Success = false,
                Errors = validationResult
                    .Errors
                    .Select(a => a.ErrorMessage)
                    .ToList(),
                Message = "delete failed"
            };

        var category = await _categoryRepository.GetByIdAsync(request.DeleteCategory.Id);

        if (category is null)
            return new BaseCommandResponse
            {
                Success = false,
                Message = "category is null. delete failed"
            };


        await _categoryRepository.DeleteCategoryAsync(category);
        return new BaseCommandResponse
        {
            Success = true,
            Message = "delete success"
        };
    }
}