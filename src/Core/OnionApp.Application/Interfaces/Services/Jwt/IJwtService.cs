using OnionApp.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace OnionApp.Application.Interfaces.Services.Jwt
{
    public interface IJwtService
    {
        Task<JwtSecurityToken> CreateAccessToken(AppUser user);
    }
}
