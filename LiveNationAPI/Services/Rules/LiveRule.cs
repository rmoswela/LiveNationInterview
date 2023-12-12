namespace LiveNationAPI;

public class LiveRule : IRule
{
    public int OrderOfExecution => 2;

    public bool IsDivisibleByThree(uint number)
    {
        return number % 3 == 0;
    }

    public string ApplyRule(uint number)
    {
        if (IsDivisibleByThree(number))
        {
            return "Live";
        }

        return null;
    }
}
