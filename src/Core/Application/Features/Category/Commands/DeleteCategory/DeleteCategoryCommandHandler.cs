using Application.Interfaces.UnitOfWork;
using Application.Models.Responses;
using MediatR;
using MGH.Exceptions;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResponse>
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
        await _unitOfWork.SaveChangeAsync(cancellationToken);
        return new ApiResponse(new List<string> { "delete success" });
    }
}