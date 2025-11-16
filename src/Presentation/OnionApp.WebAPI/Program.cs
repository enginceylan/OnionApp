using OnionApp.Application;
using OnionApp.Persistance;
using OnionApp.Persistance.Contexts;
using OnionApp.Infrastructure;

namespace OnionApp.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers()
                            .ConfigureApiBehaviorOptions(options =>
                            {
                                // Otomatik model validation'ý devre dýþý býrak
                                options.SuppressModelStateInvalidFilter = true;
                            });

            builder.Services.RegisterPersistanceServices(builder.Configuration);
            builder.Services.RegisterApplicationServices();
            builder.Services.RegisterInfrastructureServices(builder.Configuration);
            builder.Services.RegisterAPIServices(builder.Configuration,builder.Host);

            var app = builder.Build();

            #region SEED METODUNUN TETIKLENMESI
            
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            // scope.ServiceProvider --> IoC ile haberleþebilen bir obje, GetRequiredService ile, IoC'den, istediðimiz tipdeki obje talep edebiliyoruz. 
            await dbContext.SeedAsync(); 

            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomExceptionHandler(); // UseCustomExceptionHandler isimli metod (middleware), Application projesi içerisindeki PipeLineExtensions classý içinde yazýlmýþ bir extension metoddur. Var olan ExceptionHandler middleware'inin kendimize göre uyarlanmýþ halini içerir.


            // Aþaðýdaki 2 middleware [Authorize] attribute'unun çalýþabilmesi ve görevini yerine getirebilmesi için eklenmelidir : 
            //----------------------------------------------------------------
            app.UseAuthentication();
            app.UseAuthorization();
            //----------------------------------------------------------------


            app.MapControllers();

            app.Run();
        }
    }
}
