using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Validation;
using Application.Models.Responses;
using MediatR;
using MGH.Exceptions;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<ApiResponse>
{
    public UpdateCategoryDto  UpdateCategoryDto { get; set; }
    public string IpAddress { get; set; }      
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidationService _validationService;


    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IValidationService validationService)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _validationService = validationService;
    }

    public async Task<ApiResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validationService.Validate<UpdateCategoryCommandValidator>(request);
        
        var category = await _unitOfWork
            .CategoryRepository
            .GetByIdAsync(request.UpdateCategoryDto.Id, cancellationToken);

        if (category is null)
            throw new BadRequestException("category not found");

        category.Title = request.UpdateCategoryDto.Title;
        category.Code = request.UpdateCategoryDto.Code;
        category.Description = request.UpdateCategoryDto.Description;

        _unitOfWork.CategoryRepository
            .UpdateCategory(category);

        await _unitOfWork.SaveChangeAsync(cancellationToken);

        return new ApiResponse("update success");
    }
}