using MediatR;
using OnionApp.Application.Interfaces.InMemoryCache;

namespace OnionApp.Application.Behaviors
{
    public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICachableQuery
    {
        private readonly ICacheService _cacheService;

        public CacheBehavior(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var cachedResponse = _cacheService.Get<TResponse>(request.CacheKey);

            if (cachedResponse != null)
                return cachedResponse;
                

            var response = await next();

            _cacheService.Set(request.CacheKey, response, TimeSpan.FromMinutes(request.CacheTime));

            return response;
        }
    }
}
