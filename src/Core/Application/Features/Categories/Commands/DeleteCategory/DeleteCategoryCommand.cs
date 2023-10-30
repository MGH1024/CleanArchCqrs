using Application.Features.Categories.Commands.CreateCategory;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Validation;
using Application.Models.Responses;
using MediatR;
using MGH.Exceptions;

namespace Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<ApiResponse>
{
    public DeleteCategoryDto DeleteCategoryDto { get; set; }
    public string IpAddress { get; set; }
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidationService _validationService;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IValidationService validationService)
    {
        _unitOfWork = unitOfWork;
        _validationService = validationService;
    }

    public async Task<ApiResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validationService.Validate<CreateCategoryCommandValidator>(request);

        var category =
            await _unitOfWork.CategoryRepository.GetByIdAsync(request.DeleteCategoryDto.Id, cancellationToken);

        if (category is null)
            throw new BadRequestException("category not found");

        _unitOfWork.CategoryRepository.DeleteCategory(category);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
        return new ApiResponse(new List<string> { "delete success" });
    }
}