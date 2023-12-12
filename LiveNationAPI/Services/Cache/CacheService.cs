using Microsoft.Extensions.Caching.Memory;

namespace LiveNationAPI;

internal class CacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public NumberRangeResponseDto GetCachedValue(string key)
    {
        if (_memoryCache.TryGetValue(key, out NumberRangeResponseDto cachedValue))
        {
            return cachedValue;
        }

        return null;
    }

    public NumberRangeResponseDto SetCacheValue(NumberRangeResponseDto numberRangeResponse, string key)
    {
        throw new NotImplementedException();
    }
}
