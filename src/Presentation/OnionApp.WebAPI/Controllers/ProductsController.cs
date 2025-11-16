using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Products.Commands.CreateProduct;
using OnionApp.Application.Features.Products.Queries.GetAllActiveProducts;
using OnionApp.Application.Features.Products.Queries.GetProductById;
using OnionApp.Application.Features.Products.Queries.GetProductsByCategory;
using OnionApp.Application.Features.Products.Queries.GetProductsByPrice;

namespace OnionApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var test = 10;

            var request = new GetProductByIdQuery() { Id = id };
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllActiveProductsQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("getbycategory")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "JustAdmin")]
        public async Task<IActionResult> GetByCategory(
            [FromQuery] GetProductsByCategoryQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("getbyprice")]
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [Authorize(AuthenticationSchemes = "Bearer",Policy = "AdminAndUser")]
        public async Task<IActionResult> GetByPrice(
            [FromQuery] GetProductsByPriceQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand request)
        {
            var response = await _mediator.Send(request);

            return CreatedAtAction("GetById", new { id = response.Data.Id }, response.Data);
        }
    }
}
