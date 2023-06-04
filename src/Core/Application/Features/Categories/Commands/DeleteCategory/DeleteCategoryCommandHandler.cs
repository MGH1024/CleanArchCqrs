using Application.Contracts.Messaging;
using Application.DTOs.Category.Validators;
using Application.Exceptions;
using Application.Models.Responses;
using Domain.Repositories;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.DeleteCategory.Id);

        if (category is null)
            throw new BadRequestException("category not found");

        _unitOfWork.CategoryRepository.DeleteCategory(category);
        await _unitOfWork.Save();
        return new ApiResponse(new List<string> { "delete success" });
    }
}