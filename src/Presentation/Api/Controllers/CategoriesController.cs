using MediatR;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Category.Queries.GetCategories;
using Application.Features.Category.Queries.GetCategory;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Admin")]
public class CategoriesController : AppController
{
    public CategoriesController(ISender sender) : base(sender)
    {
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await Sender.Send(new GetCategoriesQuery()));
    }

    [HttpGet("get-category-by-id")]
    public async Task<IActionResult> GetCategory([FromQuery] GetCategoryByIdDto getCategoryByIdDto)
    {
        return Ok(await Sender.Send(new GetCategoryQuery { Id = getCategoryByIdDto.Id }));
    }

    [HttpPost("create-category")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategory)
    {
        var command = new CreateCategoryCommand { CreateCategory = createCategory, IpAddress = IpAddress() };
        return Ok(await Sender.Send(command));
    }

    // PUT: api/Categories/5
    [HttpPut("update-category")]
    public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryDto updateCategoryDto)
    {
        var command = new UpdateCategoryCommand { UpdateCategoryDto = updateCategoryDto };
        return Ok(await Sender.Send(command));
    }

    // DELETE: api/Categories/5
    [HttpDelete("delete-category")]
    public async Task<IActionResult> DeleteCategory(DeleteCategoryDto deleteCategoryDto)
    {
        var command = new DeleteCategoryCommand { DeleteCategoryDto = deleteCategoryDto };
        return Ok(await Sender.Send(command));
    }
}