namespace LiveNationAPI;

public class NationRule : IRule
{
    public int OrderOfExecution => 3;

    public bool IsDivisibleByFive(uint number)
    {
        return number % 5 == 0;
    }

    public string ApplyRule(uint number)
    {
        if (IsDivisibleByFive(number))
        {
            return "Nation";
        }

        return null;
    }
}
