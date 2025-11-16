using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionApp.Application.Interfaces.Repositories.Categories;
using OnionApp.Application.Interfaces.Repositories.Products;
using OnionApp.Domain.Entities.Identity;
using OnionApp.Persistance.Contexts;
using OnionApp.Persistance.Repositories.Categories;
using OnionApp.Persistance.Repositories.Products;

namespace OnionApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void RegisterPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            // Artık uygulamada AppDbContext tipindne bir nesne, injection ile talep edildiğinde buradan verilecek.
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlServerConnStr")));


            // Aşağıdaki register işlemi ile , identity kütüpohanesinden gelen UserManager ve RoleManager sınıfları register edilmiş oluyor. 
            //-----------------------------------------------------------------
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
            //-----------------------------------------------------------------


            // Esasında aşağıdaki Repository register'ları için AddSinleton uygundur ancak, yularıda services.AddDbContext ile context register ediliyor ya, services.AddDbContext, ilgili context'i Scoped olarak rtegister ediyor. 

            services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            services.AddScoped<IProductQueryRepository, ProductQueryRepository>();
            services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();

            
        }
    }
}
