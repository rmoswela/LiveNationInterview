namespace LiveNationAPI;

public interface IRulesFactory
{
    IEnumerable<IRule> InstantiateRules();
}
