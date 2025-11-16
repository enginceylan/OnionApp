using Microsoft.Extensions.Caching.Memory;
using OnionApp.Application.Interfaces.InMemoryCache;

namespace OnionApp.Infrastructure.Services.InMemoryCache
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public InMemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public T? Get<T>(string key)
        {
            return _cache.TryGetValue(key, out T? data) ? data : default;
        }

        public void Set<T>(string key, T data, TimeSpan expiration)
        {
            _cache.Set(key, data, expiration);
        }
    }
}
