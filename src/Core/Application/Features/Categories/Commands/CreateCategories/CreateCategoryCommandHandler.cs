using Application.Contracts.Messaging;
using Application.Models.Responses;
using AutoMapper;
using Domain.Entities.Shop;
using Domain.Repositories;

namespace Application.Features.Categories.Commands.CreateCategories;

public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, ApiResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ApiResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request.CreateCategory);
        await _unitOfWork.CategoryRepository.CreateCategoryAsync(category);
        await _unitOfWork.Save();
        return new ApiResponse(new List<string> { "created" });
    }
}