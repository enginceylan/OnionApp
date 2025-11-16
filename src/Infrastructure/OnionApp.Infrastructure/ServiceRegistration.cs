using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionApp.Application.Interfaces.InMemoryCache;
using OnionApp.Application.Interfaces.Services.Jwt;
using OnionApp.Infrastructure.Services.InMemoryCache;
using OnionApp.Infrastructure.Services.Jwt;
using TokenOptions = OnionApp.Infrastructure.Services.Jwt.TokenOptions;

namespace OnionApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // appsettings.json da adı TokenOptions olan bir düğüm var, onu oku ve TokenOptions tipindeki nesneye dönüştür, sonra bu nesneyi IOptions<> ile isteyen yere inject et : 
            services.Configure<TokenOptions>(configuration.GetSection("TokenOptions"));

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ICacheService, InMemoryCacheService>();
        }
    }
}
