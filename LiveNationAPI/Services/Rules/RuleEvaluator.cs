namespace LiveNationAPI;

public class RuleEvaluator : IRuleEvaluator
{
    private readonly IRule[] _rules;

    public RuleEvaluator(IRulesFactory rulesFactory)
    {
        _rules = rulesFactory.InstantiateRules().ToArray();
    }

    public string EvaluateRule(uint number)
    {
        var orderedRules = _rules.OrderBy(x => x.OrderOfExecution).ToArray();

        foreach (var rule in orderedRules)
        {
            var result = rule.ApplyRule(number);
            if (result != null)
            {
                return result;
            }
        }

        return number.ToString();
    }
}
