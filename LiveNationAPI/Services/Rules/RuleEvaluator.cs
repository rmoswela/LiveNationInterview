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
        foreach (var rule in _rules)
        {
            var result = rule.ApplyRule(number);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}
