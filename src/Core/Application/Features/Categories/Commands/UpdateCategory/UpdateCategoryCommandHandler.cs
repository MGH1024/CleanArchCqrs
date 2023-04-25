using Application.Responses;
using Application.Contracts.Messaging;
using Application.Contracts.Persistence;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;


    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork
            .CategoryRepository
            .GetByIdAsync(request.UpdateCategory.Id);

        if (category is null)
            return new BaseCommandResponse
            {
                Success = false,
                Message = "category is null. update failed"
            };

        category.Title = request.UpdateCategory.Title;
        category.Code = request.UpdateCategory.Code;
        category.Description = request.UpdateCategory.Description;

        await _unitOfWork.CategoryRepository
            .UpdateCategoryAsync(category);

        await _unitOfWork.Save();

        return new BaseCommandResponse
        {
            Success = true,
            Message = "update success",
            Id = category.Id
        };
    }
}