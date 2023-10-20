using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Validation;
using Application.Models.Responses;
using AutoMapper;
using MediatR;
using MGH.Exceptions;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidationService _validationService;

    public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IValidationService validationService)
    {
        _mapper = mapper ;
        _unitOfWork = unitOfWork ;
        _validationService = validationService;
    }

    public async Task<ApiResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validationService
            .Validate<CreateCategoryDtoValidator>(request.CreateCategory);

        var isDuplicateTitle = await _unitOfWork
            .CategoryRepository
            .IsCategoryRegisteredAsync(request.CreateCategory.Title, cancellationToken);

        if (isDuplicateTitle)
            throw new DuplicateException("Title", typeof(Domain.Entities.Shop.Category));

        var category = _mapper
            .Map<Domain.Entities.Shop.Category>(request.CreateCategory);

        await _unitOfWork
            .CategoryRepository
            .CreateCategoryAsync(category, cancellationToken);

        await _unitOfWork
            .SaveChangeAsync(cancellationToken);

        return new ApiResponse(new List<string> { "created" });
    }
}