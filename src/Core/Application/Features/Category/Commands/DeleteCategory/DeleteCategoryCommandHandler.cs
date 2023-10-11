using Application.Contracts.Messaging;
using Application.Models.Responses;
using Domain.Repositories;
using MGH.Exceptions;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.DeleteCategoryDto.Id, cancellationToken);

        if (category is null)
            throw new BadRequestException("category not found");

        _unitOfWork.CategoryRepository.DeleteCategory(category);
        await _unitOfWork.SaveAsync(cancellationToken);
        return new ApiResponse(new List<string> { "delete success" });
    }
}