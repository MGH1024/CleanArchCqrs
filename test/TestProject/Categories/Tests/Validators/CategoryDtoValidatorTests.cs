﻿using Domain.Repositories;
using FluentValidation.TestHelper;
using TestProject.Categories.Builders;
using TestProject.Categories.Fixtures;
using Application.DTOs.Category.Validators;
using Application.Features.Category.Commands.CreateCategory;

namespace TestProject.Categories.Tests.Validators;

public class CategoryDtoValidatorTests : IClassFixture<CreateCategoryCommandHandlerFixture>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly CreateCategoryCommandHandler _categoryCommandHandler;

    public CategoryDtoValidatorTests(CreateCategoryCommandHandlerFixture categoryCommandHandlerFixture)
    {
        _unitOfWork = categoryCommandHandlerFixture.UnitOfWork;
        _categoryCommandHandler = categoryCommandHandlerFixture.CreateCategoryCommandHandler;
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void GivenEmptyTitle_WhenValidate_ThenWillInvalid(string title)
    {
        var dto = new CategoryDtoBuilder()
            .WithCode(1)
            .WithDescription("desc")
            .WithTitle(title)
            .Build();
        var validator = new CategoryDtoValidator();
        var result = validator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.Title);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GivenInvalidCode_WhenValidate_ThenWillInvalid(int code)
    {
        var dto = new CategoryDtoBuilder()
            .WithCode(code)
            .WithDescription("desc")
            .WithTitle("title")
            .Build();
        var validator = new CategoryDtoValidator();
        var result = validator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.Code);
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GivenInvalidId_WhenValidate_ThenWillInvalid(int id)
    {
        var dto = new CategoryDtoBuilder()
            .WithId(id)
            .Build();
        var validator = new CategoryDtoValidator();
        var result = validator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.Id);
    }
}