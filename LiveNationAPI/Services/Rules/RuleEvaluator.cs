namespace LiveNationAPI;

public class RuleEvaluator : IRuleEvaluator
{
    private readonly IRulesFactory _rulesFactory;

    public RuleEvaluator(IRulesFactory rulesFactory)
    {
        _rulesFactory = rulesFactory;
    }

    public string EvaluateRule(uint number)
    {
        throw new NotImplementedException();
    }
}
