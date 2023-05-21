using Domain.Entities.Shop;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.Repositories;
using UnitTest.EfLogging;
using Xunit.Abstractions;

namespace UnitTest.RepositoryTest;

public class CategoryRepositoryTest
{
    private readonly ITestOutputHelper _output;

    public CategoryRepositoryTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task GetAllAsync_Test()
    {
        //arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase($"AppDbContextForTesting{Guid.NewGuid()}")
            .Options;

        await using var context = new AppDbContext(options);
        await context.Categories.AddRangeAsync(new Category
        {
            Id = 1,
            Title = "cat1",
            Code = 1,
        }, new Category
        {
            Id = 2,
            Title = "cat2",
            Code = 2,
        });

        await context.SaveChangesAsync();

        var catRepository = new CategoryRepository(context);

        //act
        var categories =
            await catRepository
                .GetAllAsync();

        //assert
        Assert.Equal(2, categories.ToList().Count);
    }

    [Fact]
    public async Task GetAllAsync_Test_SqlLite()
    {
        //arrange
        var connectionStringBuilder =
            new SqliteConnectionStringBuilder { DataSource = ":memory:" };
        var connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseLoggerFactory(new LoggerFactory(
                new[] { new LogToActionLoggerProvider((log) => { _output.WriteLine(log); }) }))
            .UseSqlite(connection)
            .Options;

        await using var context = new AppDbContext(options);
        connection.Open();
        await context.Database.EnsureCreatedAsync();

        await context.Categories.AddRangeAsync(new Category
        {
            Id = 1,
            Title = "cat1",
            Code = 1,
        }, new Category
        {
            Id = 2,
            Title = "cat2",
            Code = 2,
        });
        await context.SaveChangesAsync();

        var catRepository = new CategoryRepository(context);

        //act
        var categories =
            await catRepository
                .GetAllAsync();

        //assert
        Assert.Equal(2, categories.ToList().Count);
    }

    [Fact]
    public async Task GetById()
    {
        //arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase($"AppDbContextForTesting{Guid.NewGuid()}")
            .Options;

        await using var context = new AppDbContext(options);
        await context.Categories.AddRangeAsync(new Category
        {
            Id = 1,
            Title = "cat1",
            Code = 1,
        }, new Category
        {
            Id = 2,
            Title = "cat2",
            Code = 2,
        });

        await context.SaveChangesAsync();

        var catRepository = new CategoryRepository(context);

        //act
        var category =
            await catRepository
                .GetByIdAsync(1);


        //assert
        Assert.Equal(1, category.Id);
    }


    [Fact]
    public async Task AddCategory()
    {
        //arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase($"AppDbContextForTesting{Guid.NewGuid()}")
            .Options;

        await using var context = new AppDbContext(options);
        var catRepository = new CategoryRepository(context);

        var category = new Category
        {
            Id = 1,
            Code = 1,
            Title = "cat1",
        };

        //act
        await catRepository.CreateCategoryAsync(category);
        await context.SaveChangesAsync();


        //assert
        var addedCategory = await
            catRepository.GetByIdAsync(1);

        Assert.Equal(1, addedCategory.Id);
    }
}