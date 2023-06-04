using Application.Contracts.Messaging;
using Application.Exceptions;
using Application.Models.Responses;
using Domain.Repositories;

namespace Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;


    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
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

        return new ApiResponse()
        {
            Messages = new List<string> {"update success"}
        };
    }
}