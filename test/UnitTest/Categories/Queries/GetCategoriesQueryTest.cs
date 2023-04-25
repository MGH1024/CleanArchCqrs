using Moq;
using Shouldly;
using AutoMapper;
using UnitTest.Mocks;
using Application.Profiles;
using Application.Responses;
using Application.DTOs.Category;
using Application.Contracts.Persistence;
using Application.Features.Categories.Queries.GetCategories;

namespace UnitTest.Categories.Queries
{
    public class GetCategoriesQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;

        public GetCategoriesQueryTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockUow = MockUnitOfWork.GetUnitOfWork();
        }

        [Fact]
        public async Task GetCategories()
        {
            var handler = 
                new GetCategoriesQueryHandler(_mapper,_mockUow.Object);

            var result = await handler
                .Handle(new GetCategoriesQuery(),CancellationToken.None);

            result.ShouldBeOfType<BaseQueryResponse<List<CategoryDetail>>>();
            result.Data.Count.ShouldBe(3);
        }

    }
}
