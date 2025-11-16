using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionApp.Application.Behaviors;
using OnionApp.Application.Middlewares;
using System.Reflection;

namespace OnionApp.Application
{
    public static class ServiceRegistration
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assembly);
            services.AddMediatR(x => x.RegisterServicesFromAssembly(assembly));


            services.AddTransient<ExceptionHandlerMiddleware>();
            // yukarıdaki middleware (ExceptionHandlerMiddleware) IMiddleware'den implement yöntemiyle elde edildiğ için IoC ye register edilmelidir. 


            // FluentValidation kullanan, AbstractValidator sınıfından kalıtım almış sınıflarımızı IoC ye register ediyoruz.
            services.AddValidatorsFromAssembly(assembly);


            // Mediatr pipeline için yazdığımız behavior'ı IoC ye register ettik

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        }
    }
}
