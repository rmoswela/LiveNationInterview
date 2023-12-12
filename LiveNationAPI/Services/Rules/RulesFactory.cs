namespace LiveNationAPI;

public class RulesFactory : IRulesFactory
{
    public IEnumerable<IRule> InstantiateRules()
    {
        var rules = new List<IRule>()
        {
            new LiveRule(),
            new NationRule(),
            new LiveNationRule(new LiveRule(), new NationRule())
        };

        return rules;
    }
}
