namespace LiveNationAPI;

public interface ICacheService
{
    NumberRangeResponseDto GetCachedValue(string key);
    NumberRangeResponseDto SetCacheValue(NumberRangeResponseDto numberRangeResponse, string key);
}
