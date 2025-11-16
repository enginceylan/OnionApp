namespace OnionApp.Application.Interfaces.InMemoryCache
{
    public interface ICachableQuery
    {
        string CacheKey { get;}
        double CacheTime { get; }
    }
}
