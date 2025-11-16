using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnionApp.Application.Features.Auth.Commands.GetAccessToken;
using OnionApp.Domain.Entities.Identity;

namespace OnionApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("gettoken")]
        public async Task<IActionResult> GetToken([FromBody] AccessTokenCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
