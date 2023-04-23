using Application.Contracts.Messaging;
using Application.Contracts.Persistence;
using Application.Responses;
using AutoMapper;
using Domain.Shop;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, BaseCommandResponse>
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
        var category = _mapper.Map<Category>(request.CreateCategory);
        category = await _categoryRepository.CreateCategoryAsync(category);

        return new BaseCommandResponse
        {
            Id = category.Id,
            Message = "create success",
            Success = true,
        };
    }
}