using MediatR;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Application.Features.Products.Queries.GetProducts;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetProduct;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : AppController
    {
        public ProductsController(ISender sender) : base(sender)
        {
        }


        [HttpGet("")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await Sender.Send(new GetProductsQuery { }));
        }

        [HttpGet("get-product-by-id")]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductById getProductById)
        {
            return Ok(await Sender.Send(new GetProductQuery { Id = getProductById.Id }));
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct createProduct)
        {
            var command = new CreateProductCommand
            {
                CreateProduct = createProduct
            };
            return Ok(await Sender.Send(command));
        }

        [HttpPut("update-product")]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProduct updateProduct)
        {
            var command = new UpdateProductCommand { UpdateProduct = updateProduct };
            return Ok(await Sender.Send(command));
        }


        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(DeleteProduct deleteProduct)
        {
            var command = new DeleteProductCommand { DeleteProduct = deleteProduct };
            return Ok(await Sender.Send(command));
        }
    }
}