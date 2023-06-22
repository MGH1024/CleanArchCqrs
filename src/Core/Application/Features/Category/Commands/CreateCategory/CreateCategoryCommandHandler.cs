using Application.Contracts.Infrastructure.Validation;
using Application.Contracts.Messaging;
using Application.DTOs.Category.Validators;
using Application.Models.Responses;
using AutoMapper;
using Domain.Repositories;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidationService _validationService;

    public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IValidationService validationService)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
    }

    public async Task<ApiResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validationService
            .Validate<CreateCategoryDtoValidator>(request.CreateCategory);

        var category = _mapper
            .Map<Domain.Entities.Shop.Category>(request.CreateCategory);

        await _unitOfWork
            .CategoryRepository
            .CreateCategoryAsync(category, cancellationToken);

        await _unitOfWork
            .Save(cancellationToken);

        return new ApiResponse(new List<string> { "created" });
    }
}