﻿using Application.DTOs.Category.Validators;
using FluentValidation.TestHelper;
using TestProject.Categories.Builders;

namespace TestProject.Categories.Tests.Validators;

public class DeleteCategoryByIdDtoValidatorTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GivenInvalidId_WhenValidate_ThenWillInvalid(int id)
    {
        var dto = new GetCategoryByIdDtoBuilder()
            .WithId(id)
            .Build();
        var validator = new GetCategoryByIdDtoValidator();
        var result = validator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.Id);
    }
}