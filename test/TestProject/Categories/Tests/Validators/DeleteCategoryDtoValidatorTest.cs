using Application.DTOs.Category.Validators;
using FluentValidation.TestHelper;
using TestProject.Categories.Builders;

namespace TestProject.Categories.Tests.Validators;

public class DeleteCategoryDtoValidatorTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void GivenInvalidId_WhenValidate_ThenWillInvalid(int id)
    {
        var dto = new DeleteCategoryDtoBuilder()
           .WithId(id)
            .Build();
        var validator = new DeleteCategoryDtoValidator();
        var result = validator.TestValidate(dto);

        result.ShouldHaveValidationErrorFor(x => x.Id);
    }
}