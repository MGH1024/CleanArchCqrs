using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Commands.DeleteProduct;
using Application.Features.Product.Commands.UpdateProduct;
using Application.Features.Product.Queries.GetProduct;
using Application.Features.Product.Queries.GetProducts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Roles = "ProductManagement")]
    public class ProductsController : AppController
    {
        public ProductsController(ISender sender) : base(sender)
        {
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await Sender.Send(new GetProductsQuery()));
        }

        [HttpGet("get-product-by-id")]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductByIdDto getProductByIdDto)
        {
            return Ok(await Sender.Send(new GetProductQuery { Id = getProductByIdDto.Id }));
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var command = new CreateProductCommand
            {
                CreateProductDto = createProductDto
            };
            return Ok(await Sender.Send(command));
        }

        [HttpPut("update-product")]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            var command = new UpdateProductCommand { UpdateProductDto = updateProductDto };
            return Ok(await Sender.Send(command));
        }


        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(DeleteProductDto deleteProductDto)
        {
            var command = new DeleteProductCommand { DeleteProductDto = deleteProductDto };
            return Ok(await Sender.Send(command));
        }
    }
}