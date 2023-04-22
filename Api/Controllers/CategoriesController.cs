using MediatR;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Category;
using Application.Features.Category.Requests.Queries;
using Application.Features.Category.Requests.Commands;
using Application.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        
        [HttpGet("")]
        public async Task<IActionResult> GetCategories([FromQuery] GetParameter resourceParameter)
        {
            return Ok(await _mediator.Send(new GetCategoryListRequest { }));
        }

        [HttpGet("get-category-by-id")]
        public async Task<IActionResult> GetCategory([FromQuery] GetCategoryById getCategoryById)
        {
            return Ok(await _mediator.Send(new GetCategoryRequest { Id = getCategoryById.Id }));
        }

        // POST: api/Categories
        [HttpPost("create-category")]
        public async Task<ActionResult> Post([FromBody] CreateCategory createCategory)
        {
            var command = new CreateCategoryCommand { CreateCategory = createCategory };
            return Ok(await _mediator.Send(command));
        }
        
        // PUT: api/Categories/5
        [HttpPut("update-category")]
        public async Task<ActionResult> Put([FromBody] UpdateCategory updateCategory)
        {
            var command = new UpdateCategoryCommand { UpdateCategory = updateCategory };
            return Ok(await _mediator.Send(command));
        }
        
        // DELETE: api/Categories/5
        [HttpDelete("delete-category")]
        public async Task<ActionResult> Delete(DeleteCategory deleteCategory)
        {
            var command = new DeleteCategoryCommand { DeleteCategory = deleteCategory };
            return Ok(await _mediator.Send(command));
        }
    }
}