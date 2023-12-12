namespace LiveNationAPI;

public interface IRule
{
    int OrderOfExecution { get; }
    string ApplyRule(uint number);
}
