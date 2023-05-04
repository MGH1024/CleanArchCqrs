using Application.Responses;
using Application.Contracts.Messaging;
using Application.Contracts.Persistence;
using Application.DTOs.Category.Validators;
using Application.Exceptions;

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
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.DeleteCategory.Id);

        if (category is null)
            throw new BadRequestException("category not found");

        _unitOfWork.CategoryRepository.DeleteCategory(category);
        await _unitOfWork.Save();
        return new BaseCommandResponse
        {
            Success = true,
            Message = "delete success"
        };
    }
}