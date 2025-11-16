using MediatR;
using OnionApp.Application.Models.Dtos.Auth;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Auth.Commands.GetAccessToken
{
    public class AccessTokenCommand:IRequest<Response<GetAccessTokenDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
