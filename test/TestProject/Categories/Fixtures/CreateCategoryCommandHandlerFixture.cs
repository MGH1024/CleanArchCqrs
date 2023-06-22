using AutoMapper;
using NSubstitute;
using TestProject.Base;
using Domain.Repositories;
using Application.Contracts.Infrastructure.Validation;
using Application.Features.Category.Commands.CreateCategory;

namespace TestProject.Categories.Fixtures;

public class CreateCategoryCommandHandlerFixture
{
    private readonly IMapper _mapper;
    private readonly IValidationService _validationService;

    public readonly IUnitOfWork UnitOfWork;
    public CreateCategoryCommandHandler CreateCategoryCommandHandler;

    public CreateCategoryCommandHandlerFixture()
    {
        _mapper = Substitute.For<IMapper>();
        UnitOfWork = Substitute.For<IUnitOfWork>();
        _validationService = new ValidationServiceFixture()._validationService;
        CreateCategoryCommandHandler = new CreateCategoryCommandHandler(_mapper, UnitOfWork, _validationService);
    }
    
    
}