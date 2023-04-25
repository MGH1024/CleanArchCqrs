using Moq;
using Application.Contracts.Persistence;

namespace UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockCategoryRepository = MockCategoryRepository.GetCategoryRepository();
            mockUow.Setup(a => a.CategoryRepository).Returns(mockCategoryRepository.Object);
            return mockUow;
        }
    }
}