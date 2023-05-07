using AutoMapper;
using Application.Responses;
using Application.Contracts.Messaging;
using Domain.Entities.Shop;
using Domain.Repositories;

namespace Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, BaseCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request.CreateCategory);
        category = await _unitOfWork.CategoryRepository.CreateCategoryAsync(category);
        await _unitOfWork.Save();
        return new BaseCommandResponse
        {
            Id = category.Id,
            Message = "create success",
            Success = true,
        };
    }
}