using FluentValidation;
using Microsoft.AspNetCore.Http;
using OnionApp.Application.Exceptions;
using OnionApp.Application.Models.ResponseWrappers;
using System.Text.Json;

namespace OnionApp.Application.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                // request'i burada çalıştır, catch'e düşüyorsa sonraki middleware'e ilet.
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public async static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statusCode = GetStatusCode(ex);

            List<string> errorMessages = new List<string>();

            if (ex is ValidationException)
            {
                var errors = ((ValidationException)ex).Errors;
                foreach (var error in errors)
                {
                    errorMessages.Add(error.ErrorMessage);
                }
            }
            else
                errorMessages = new() { { ex.Message } };

            // Yukarıda, elde ettiğimiz exception a bakarak, hata mesajını ve statusCode u oluşturduk. Şimdi aş. gibi bir response oluşturup client'a döndürmemiz lazım : 

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new Response<NoData>(errorMessages, statusCode);

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));

        }
        public static int GetStatusCode(Exception ex)
        {
            if (ex is BadRequestException)
                return StatusCodes.Status400BadRequest;
            else if (ex is NotFoundException)
                return StatusCodes.Status404NotFound;
            else if (ex is ValidationException)
                return StatusCodes.Status422UnprocessableEntity;

            return StatusCodes.Status500InternalServerError;
        }
    }
}
