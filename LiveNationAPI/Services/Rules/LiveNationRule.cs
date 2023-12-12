namespace LiveNationAPI;

public class LiveNationRule : IRule
{
    private readonly LiveRule _liveRule;
    private readonly NationRule _nationRule;

    public LiveNationRule(LiveRule liveRule, NationRule nationRule)
    {
        _liveRule = liveRule;
        _nationRule = nationRule;
    }

    public int OrderOfExecution => 1;

    public string ApplyRule(uint number)
    {
        if (_liveRule.IsDivisibleByThree(number) && _nationRule.IsDivisibleByFive(number))
        {
            return "LiveNation";
        }

        return null;
    }
}
