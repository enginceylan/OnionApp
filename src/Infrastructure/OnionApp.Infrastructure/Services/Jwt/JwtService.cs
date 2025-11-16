using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnionApp.Application.Interfaces.Services.Jwt;
using OnionApp.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnionApp.Infrastructure.Services.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenOptions _tokenOptions;
        public JwtService(IOptions<TokenOptions> options, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _tokenOptions = options.Value;
        }
        public async Task<JwtSecurityToken> CreateAccessToken(AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
                // controller tarafındaki [Authorize(AuthenticationSchemes ="Bearer", Roles = "Admin")] kısmında yer alan Roles = "Admin" kısmı için, burada role claim eklenirken isim olarak mutlaka ClaimTypes.Role kullanılmalıdır.
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));

            var tokenObj = 
                new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                expires: DateTime.Now.AddMinutes(_tokenOptions.TokenExpiration),
                notBefore: DateTime.Now,
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            return tokenObj;
        }
    }
}
