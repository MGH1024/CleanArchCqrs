using Application.Responses;
using Application.Contracts.Messaging;
using Application.Contracts.Persistence;
using Application.Exceptions;

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
            throw new BadRequestException("category not found");

        category.Title = request.UpdateCategory.Title;
        category.Code = request.UpdateCategory.Code;
        category.Description = request.UpdateCategory.Description;

        _unitOfWork.CategoryRepository
            .UpdateCategory(category);

        await _unitOfWork.Save();

        return new BaseCommandResponse
        {
            Success = true,
            Message = "update success",
            Id = category.Id
        };
    }
}