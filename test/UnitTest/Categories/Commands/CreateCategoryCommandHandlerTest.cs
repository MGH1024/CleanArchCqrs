using Moq;
using Shouldly;
using AutoMapper;
using UnitTest.Mocks;
using Application.Profiles;
using Application.Responses;
using Application.DTOs.Category;
using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.CreateCategory;

namespace UnitTest.Categories.Commands
{
    public class CreateCategoryCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateCategory _createCategory;

        public CreateCategoryCommandHandlerTest()
        {
            var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });

            _mapper = mapperConfig.CreateMapper();
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            _createCategory = new CreateCategory
            {
                Code = 3,
                Title = "new Category",
                Description = "some description",
            };
        }

        [Fact]
        public async Task CreateCategory()
        {
            var handler =
                new CreateCategoryCommandHandler(_mapper, _mockUow.Object);

            var result = await handler
                .Handle(new CreateCategoryCommand
                {
                    CreateCategory = _createCategory
                }, CancellationToken.None);

            var categories = await _mockUow
                .Object.CategoryRepository
                .GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            categories.Count().ShouldBe(4);
        }
    }
}