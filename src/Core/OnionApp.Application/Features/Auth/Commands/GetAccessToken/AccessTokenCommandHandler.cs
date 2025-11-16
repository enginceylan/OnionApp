using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionApp.Application.Exceptions;
using OnionApp.Application.Interfaces.Services.Jwt;
using OnionApp.Application.Models.Dtos.Auth;
using OnionApp.Application.Models.ResponseWrappers;
using OnionApp.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace OnionApp.Application.Features.Auth.Commands.GetAccessToken
{
    public class AccessTokenCommandHandler : IRequestHandler<AccessTokenCommand, Response<GetAccessTokenDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtService _jwtService;

        public AccessTokenCommandHandler(UserManager<AppUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }
        public async Task<Response<GetAccessTokenDto>> Handle(AccessTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                throw new BadRequestException("Kullanıcı Bulunamadı");

            bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!checkPassword)
                throw new BadRequestException("Şifre Yanlış!!");

           
            var tokenObj = await _jwtService.CreateAccessToken(user);

            string token = new JwtSecurityTokenHandler().WriteToken(tokenObj);

            return new Response<GetAccessTokenDto>(new GetAccessTokenDto()
            {
                Token = token,
                Expiration = tokenObj.ValidTo
            },200);
        }
    }
}
