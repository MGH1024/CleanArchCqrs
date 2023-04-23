using Application.Contracts.Persistence;
using Domain.Shop;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mocks
{
    public static class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id=1,
                    Title="IT",
                    Code=1,
                    Description="It Category"
                },
                 new Category
                {
                    Id=2,
                    Title="Civil",
                    Code=1,
                    Description="Civil Category"
                },
                  new Category
                {
                    Id=3,
                    Title="Sport",
                    Code=3,
                    Description="Sport Category"
                }
            };

            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);

            mockRepo.Setup(a => a.CreateCategoryAsync(It.IsAny<Category>()))
               .Returns((Category category) =>
               {
                   categories.Add(category);
                   return Task.FromResult(category);
               });

            return mockRepo;
        }
    }
}
