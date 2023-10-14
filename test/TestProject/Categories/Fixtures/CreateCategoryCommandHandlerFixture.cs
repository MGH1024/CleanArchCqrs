using AutoMapper;
using NSubstitute;
using TestProject.Base;
using Domain.Repositories;
using Application.Features.Category.Commands.CreateCategory;
using Application.Interfaces;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.Validation;
using Moq;
using TestProject.Base.Fixtures;
using TestProject.Base.Mocks;

namespace TestProject.Categories.Fixtures;

public class CreateCategoryCommandHandlerFixture
{
    public readonly IMapper Mapper;
    //public readonly IUnitOfWork UnitOfWork;
    public readonly IValidationService ValidationService;
    public CreateCategoryCommandHandler CreateCategoryCommandHandler;
    public Mock<IUnitOfWork> UnitOfWorkMock;

    public CreateCategoryCommandHandlerFixture()
    {
        Mapper = Substitute.For<IMapper>();
        //UnitOfWork = Substitute.For<IUnitOfWork>();
        ValidationService = new ValidationServiceFixture().ValidationService;
        UnitOfWorkMock = MockUnitOfWork.GetUnitOfWork();
        CreateCategoryCommandHandler = new CreateCategoryCommandHandler(Mapper, UnitOfWorkMock.Object, ValidationService);
    }
}