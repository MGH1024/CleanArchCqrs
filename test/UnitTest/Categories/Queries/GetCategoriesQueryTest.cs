using Application.Contracts.Persistence;
using Application.DTOs.Category;
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
using System.Threading.Tasks;
using UnitTest.Mocks;

namespace UnitTest.Categories.Queries
{
    public class GetCategoriesQueryTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepo;

        public GetCategoriesQueryTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockRepo = MockCategoryRepository.GetCategoryRepository();
        }

        [Fact]
        public async Task GetCategories()
        {
            var handler = 
                new GetCategoriesQueryHandler(_mapper,_mockRepo.Object);

            var result = await handler
                .Handle(new GetCategoriesQuery(),CancellationToken.None);

            result.ShouldBeOfType<BaseQueryResponse<List<CategoryDetail>>>();
            result.Data.Count.ShouldBe(3);
        }

    }
}
