using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Diagnostics;
using System.Security.Claims;

namespace OnionApp.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        private readonly IHttpContextAccessor _accessor; // bu interface, HttpContext'3 controller dışında herhangi bir class içinde erişmemiz gerekiyorsa ihtiyacımız vardır. 

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;

            Serilog.Debugging.SelfLog.Enable(Console.Error);
            // Yukarıdaki komut kullanuılarak, eğer serilog logu yazarken bir hata oluşuyorsa onu consoleda görebiliyoruz.

            LogContext.PushProperty("EventType", "10");

            using (LogContext.PushProperty("UserName", _accessor.HttpContext.User.Identity?.IsAuthenticated == true ? _accessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value : "anonymous"))
            {
                _logger.LogInformation("REQUEST: {RequestName} | Data: {@Request}", requestName, request);
            }

            var stopwatch = Stopwatch.StartNew();

            try
            {
                var response = await next();

                stopwatch.Stop();

                _logger.LogInformation("HANDLED REQUEST: {RequestName} in {ElapsedMilliseconds}ms. RESPONSE: {@Response}",
            requestName, stopwatch.ElapsedMilliseconds, response);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
