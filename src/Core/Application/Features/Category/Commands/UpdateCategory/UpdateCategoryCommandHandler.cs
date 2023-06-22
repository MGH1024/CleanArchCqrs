using Application.Contracts.Messaging;
using Application.Models.Responses;
using Domain.Repositories;
using MGH.Exceptions;

namespace Application.Features.Category.Commands.UpdateCategory;

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
            .GetByIdAsync(request.UpdateCategoryDto.Id);

        if (category is null)
            throw new BadRequestException("category not found");

        category.Title = request.UpdateCategoryDto.Title;
        category.Code = request.UpdateCategoryDto.Code;
        category.Description = request.UpdateCategoryDto.Description;

        _unitOfWork.CategoryRepository
            .UpdateCategory(category);

        await _unitOfWork.Save(cancellationToken);

        return new ApiResponse()
        {
            Messages = new List<string> {"update success"}
        };
    }
}