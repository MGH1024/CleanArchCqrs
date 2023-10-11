using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetCategories;
using Application.Features.Category.Queries.GetCategory;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var command = new CreateCategoryCommand { CreateCategory = createCategory };
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
}