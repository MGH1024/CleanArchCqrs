﻿using FluentValidation.TestHelper;
using TestProject.Categories.Builders;
using TestProject.Categories.Fixtures;
using Application.Features.Category.Commands.CreateCategory;

namespace TestProject.Categories.Tests.Validators;

public class CreateCategoryDtoValidatorTests : IClassFixture<CreateCategoryCommandHandlerFixture>
{

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
    
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GivenInvalidCode_WhenValidate_ThenWillInvalid(int code)
    {
        var dto = new CreateCategoryDtoBuilder()
            .WithCode(code)
            .WithDescription("desc")
            .WithTitle("title")
            .Build();
        var validator = new CreateCategoryDtoValidator();
        var result = validator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.Code);
    }
}