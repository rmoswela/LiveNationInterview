namespace LiveNationAPI;

public class NationRule : IRule
{
    public string ApplyRule(uint number)
    {
        if (number % 5 == 0)
        {
            return "Nation";
        }

        return null;
    }
}
