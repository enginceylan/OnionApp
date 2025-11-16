using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Categories.Queries.GetAllActiveCategories;
using OnionApp.Application.Features.Products.Queries.GetAllActiveProducts;

namespace OnionApp.WebAPI.Controllers
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

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllActiveCategoriesQuery request)
        {
            var test = 10;

            return Ok(await _mediator.Send(request));
        }
    }
}
