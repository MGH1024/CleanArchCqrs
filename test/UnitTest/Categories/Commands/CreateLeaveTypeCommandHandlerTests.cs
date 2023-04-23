using Application.Contracts.Persistence;
using Application.DTOs.Category;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Queries.GetCategories;
using Application.Profiles;
using Application.Responses;
using AutoMapper;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Commands
{
    public class CreateCategoryCommandHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepo;
        private readonly CreateCategory _createCategory;

        public CreateCategoryCommandHandlerTest()
        {

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockRepo = MockCategoryRepository.GetCategoryRepository();

            _createCategory = new CreateCategory
            {
                Code = 3,
                Description = "some description",
                Title = "new Category"
            };
        }

        [Fact]
        public async Task CreateCategory()
        {
            var handler =
               new CreateCategoryCommandHandler(_mapper, _mockRepo.Object);

            var result = await handler
                .Handle(new CreateCategoryCommand
                {
                    CreateCategory = _createCategory
                }, CancellationToken.None);

            var categories = await _mockRepo
                .Object
                .GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            categories.Count().ShouldBe(4);
        }
    }
}
