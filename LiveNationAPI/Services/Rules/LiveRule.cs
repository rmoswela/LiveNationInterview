namespace LiveNationAPI;

public class LiveRule : IRule
{
    public string ApplyRule(uint number)
    {
        if (number % 3 == 0)
        {
            return "Live";
        }

        return null;
    }
}
