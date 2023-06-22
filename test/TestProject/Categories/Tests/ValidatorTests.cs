using Domain.Repositories;
using FluentValidation.TestHelper;
using TestProject.Categories.Builders;
using TestProject.Categories.Fixtures;
using Application.DTOs.Category.Validators;
using Application.Features.Category.Commands.CreateCategory;

namespace TestProject.Categories.Tests;

public class ValidatorTests : IClassFixture<CreateCategoryCommandHandlerFixture>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateCategoryCommandHandler _categoryCommandHandler;

    public ValidatorTests(CreateCategoryCommandHandlerFixture categoryCommandHandlerFixture)
    {
        _unitOfWork = categoryCommandHandlerFixture.UnitOfWork;
        _categoryCommandHandler = categoryCommandHandlerFixture.CreateCategoryCommandHandler;
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GivenEmptyTitle_WhenValidate_ThenWillInvalid(string title)
    {
        var dto = new CreateCategoryDtoBuilder()
            .WithCode(1)
            .WithDescription("desc")
            .WithTitle(title)
            .Build();
        var validator = new CreateCategoryDtoValidator();
        var result = validator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.Title);
    }
}