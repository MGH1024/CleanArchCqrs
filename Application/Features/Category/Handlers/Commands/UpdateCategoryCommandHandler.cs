using MediatR;
using Application.Responses;
using Application.Contracts.Persistence;
using Application.DTOs.Category.Validators;
using Application.Features.Category.Requests.Commands;

namespace Application.Features.Category.Handlers.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryValidator(_categoryRepository);
        var validationResult = await validator
            .ValidateAsync(request.UpdateCategory, cancellationToken);
        if (!validationResult.IsValid)
            return new BaseCommandResponse
            {
                Errors = validationResult
                    .Errors
                    .Select(a => a.ErrorMessage)
                    .ToList(),
                Message = "update failed",
                Success = false,
            };


        var category = await _categoryRepository.GetByIdAsync(request.UpdateCategory.Id);

        if (category is null)
            return new BaseCommandResponse
            {
                Success = false,
                Message = "category is null. update failed"
            };


        await _categoryRepository.UpdateCategoryAsync(category);

        return new BaseCommandResponse
        {
            Success = true,
            Message = "update success",
            Id = category.Id
        };
    }
}