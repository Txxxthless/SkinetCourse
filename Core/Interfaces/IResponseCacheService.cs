namespace Core.Interfaces
{
    public interface IResponseCacheService
    {
        Task ChacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive);
        Task<string> GetChachedResponseAsync(string cacheKey);
    }
}