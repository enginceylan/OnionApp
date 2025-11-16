using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnionApp.Infrastructure.Services.Jwt;
using Serilog;
using System.Text;

namespace OnionApp.WebAPI
{
    public static class ServiceRegistration
    {
        public static void RegisterAPIServices(this IServiceCollection services,IConfiguration configuration, IHostBuilder host)
        {
            #region Loglama Yapılacak Klasör Kontrolü
            
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");

            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);

            #endregion


            #region SeriLog Confg. Yapılandırılması
            
            host.UseSerilog((context, config) =>
              {
                  config.ReadFrom.Configuration(context.Configuration); // serilog için gerekli konfigurasyonu git appsettingsden oku
              }); 

            #endregion


            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

            // Aşağıdaki kısımda [Authorize] attribute'una authorization'ı nasılş yapacağını anlatmış oluyorum. "BEARER" şeması üzerinden bu doğrulamayı yapacak, bu ne demek ? "BEARER" şeması üzerinden doğrulama yapmak demek, bir JWT doğrulanacak demektir. 

            services.AddAuthentication(options =>
            {
                //kimlik doğrulamasının yapılması sırasında doğrulama şemasını belirtir.
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // gelen metadata’nın HTTPS olup olmadığını sağlamak amacıyla kullanılır.
                options.SaveToken = true; // token’nın HttpContext içinde saklanıp saklanmayacağını belirtir.
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true, //  token’ın oluşturan kaynağını kontrol eder.
                    ValidateAudience = true, //  token’ın kime yöenlik olduğunu kontrol eder.
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                    ClockSkew = TimeSpan.Zero // jeton ömrü dolduğunda zaman dilimi farklılıklarından dolayı belirtilen süre kadar daha geçerli olacağı belirtilmektedir.
                };
            });


            // Aşağıdaki kısım, swagger üzerinden test yaptığımızda, swagger'a bir jwt token girebilmemiz için yazılmıştır. Bunun sayesinde swagger'da bir authorize butonu gelecek, biz de ona tıklayıp açılan pencereye elimizdeki token'ı girebileceğiz. SADECE SWAGGERDA TEST YAPABILMEK ICIN BUNU EKLEDIK
            //-----------------------------------------------------------------------

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Auhorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                  {
                    new OpenApiSecurityScheme
                    {
                      Reference = new OpenApiReference
                      {
                        Type = ReferenceType.SecurityScheme,
                        Id="Bearer"
                      }
                    },
                    new List<string>()
                  }
                });
            });

            //-----------------------------------------------------------------------

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("JustAdmin", policy => policy.RequireRole("Admin"));
                opt.AddPolicy("AdminAndUser", policy => policy.RequireRole("Admin", "User"));
            });

            services.AddMemoryCache(); // InMemoryCache kullanabilmek için
        }
    }
}
