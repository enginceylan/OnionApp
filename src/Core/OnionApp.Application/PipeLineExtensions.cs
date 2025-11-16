using Microsoft.AspNetCore.Builder;
using OnionApp.Application.Middlewares;

namespace OnionApp.Application
{
    public static class PipeLineExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            //app.UseMiddleware<buraya, var olan ExceptionHandler middleware'ini kendimize göre uyarladığımız class tipini vereceğiz. >();

            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
