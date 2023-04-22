using MediatR;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Category;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Queries.GetCategories;
using Application.Features.Categories.Queries.GetCategory;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : AppController
    {
        public CategoriesController(ISender sender) : base(sender)
        {
        }


        [HttpGet("")]
        public async Task<IActionResult> GetCategories([FromQuery] GetParameter resourceParameter)
        {
            return Ok(await Sender.Send(new GetCategoriesQuery { }));
        }

        [HttpGet("get-category-by-id")]
        public async Task<IActionResult> GetCategory([FromQuery] GetCategoryById getCategoryById)
        {
            return Ok(await Sender.Send(new GetCategoryQuery { Id = getCategoryById.Id }));
        }

        // POST: api/Categories
        [HttpPost("create-category")]
        public async Task<ActionResult> Post([FromBody] CreateCategory createCategory)
        {
            var command = new CreateCategoryCommand { CreateCategory = createCategory };
            return Ok(await Sender.Send(command));
        }

        // PUT: api/Categories/5
        [HttpPut("update-category")]
        public async Task<ActionResult> Put([FromBody] UpdateCategory updateCategory)
        {
            var command = new UpdateCategoryCommand { UpdateCategory = updateCategory };
            return Ok(await Sender.Send(command));
        }

        // DELETE: api/Categories/5
        [HttpDelete("delete-category")]
        public async Task<ActionResult> Delete(DeleteCategory deleteCategory)
        {
            var command = new DeleteCategoryCommand { DeleteCategory = deleteCategory };
            return Ok(await Sender.Send(command));
        }
    }
}