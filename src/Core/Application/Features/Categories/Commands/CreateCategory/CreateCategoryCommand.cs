using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Constant;
using Application.Features.Category.Rules;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Validation;
using Application.Models.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand:IRequest<ApiResponse>
{
    public CreateCategoryDto CreateCategory { get; set; }
    public string IpAddress { get; set; }
    
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidationService _validationService;
    private readonly CategoryBusinessRules _categoryBusinessRules;

    public CreateCategoryCommandHandler(IMapper mapper,
        IUnitOfWork unitOfWork,
        IValidationService validationService,
        CategoryBusinessRules categoryBusinessRules)
    {
        _mapper = mapper ;
        _unitOfWork = unitOfWork ;
        _validationService = validationService;
        _categoryBusinessRules = categoryBusinessRules;
    }

    public async Task<ApiResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validationService.Validate<CreateCategoryCommandValidator>(request);
        
        var category = await _unitOfWork.CategoryRepository
            .GetByTitleAsync(request.CreateCategory.Title, cancellationToken);
        await _categoryBusinessRules.CategoryTitleShouldNotBeDuplicate(category);
        
        var newCategory = _mapper.Map<Domain.Entities.Shop.Category>(request.CreateCategory);
        await _unitOfWork.CategoryRepository.CreateCategoryAsync(newCategory, cancellationToken);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
        
        return new ApiResponse(CategoryMessages.Created);
    }
}