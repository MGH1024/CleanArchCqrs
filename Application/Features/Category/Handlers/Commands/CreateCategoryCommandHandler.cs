using MediatR;
using AutoMapper;
using Application.Responses;
using Application.Contracts.Persistence;
using Application.DTOs.Category.Validators;
using Application.Features.Category.Requests.Commands;


namespace Application.Features.Category.Handlers.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
    }

    public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateCategoryValidator(_categoryRepository);
        var validationResult = await validator
            .ValidateAsync(request.CreateCategory, cancellationToken);
        if (!validationResult.IsValid)
            return new BaseCommandResponse
            {
                Errors = validationResult
                    .Errors
                    .Select(a => a.ErrorMessage)
                    .ToList(),
                Message = "create failed",
                Success = false,
            };

        var category = _mapper.Map<Domain.Shop.Category>(request.CreateCategory);
        category = await _categoryRepository.CreateCategoryAsync(category);

        return new BaseCommandResponse
        {
            Id = category.Id,
            Message = "create success",
            Success = true,
        };
    }
}