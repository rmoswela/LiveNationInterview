namespace LiveNationAPI;

public class Generator : IGenerator
{
    private readonly ICacheService _cacheService;
    private readonly IRuleEvaluator _ruleEvaluator;

    public Generator(ICacheService cacheService, IRuleEvaluator ruleEvaluator)
    {
        _cacheService = cacheService;
        _ruleEvaluator = ruleEvaluator;
    }

    public NumberRangeResponseDto GenerateResult(NumberRangeRequestDto numberRangeRequest)
    {
        throw new NotImplementedException();
    }
}
