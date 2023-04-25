using Application.Responses;
using Application.Contracts.Messaging;
using Application.Contracts.Persistence;
using Application.DTOs.Category.Validators;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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

        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.DeleteCategory.Id);

        if (category is null)
            return new BaseCommandResponse
            {
                Success = false,
                Message = "category is null. delete failed"
            };


        await _unitOfWork.CategoryRepository.DeleteCategoryAsync(category);
        await _unitOfWork.Save();
        return new BaseCommandResponse
        {
            Success = true,
            Message = "delete success"
        };
    }
}