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
        var key = $"{numberRangeRequest.From}{numberRangeRequest.To}";
        var cachedValue = _cacheService.GetCachedValue(key);

        if (cachedValue is null)
        {
            cachedValue = ComputeResults(numberRangeRequest);
            _cacheService.SetCacheValue(cachedValue, key);
        }

        return cachedValue;
    }

    private NumberRangeResponseDto ComputeResults(NumberRangeRequestDto numberRangeRequest)
    {
        var response = new NumberRangeResponseDto();
        var summary = new SummaryCount();

        for (uint number = numberRangeRequest.From; number <= numberRangeRequest.To; number++)
        {
            var result = _ruleEvaluator.EvaluateRule(number);
            response.Result = $"{response.Result} {result}".Trim();
            RuleCount(summary, result);
        }

        response.Summary = new Summary
        {
            Live = summary.Live.ToString(),
            Nation = summary.Nation.ToString(),
            LiveNation = summary.LiveNation.ToString(),
            Integer = summary.Integer.ToString()
        };

        return response;
    }

    private void RuleCount(SummaryCount summary, string rule)
    {
        if (rule.Equals("Live"))
        {
            summary.Live++;
        }
        else if (rule.Equals("Nation"))
        {
            summary.Nation++;
        }
        else if (rule.Equals("LiveNation"))
        {
            summary.LiveNation++;
        }
        else
        {
            summary.Integer++;
        }
    }
}
