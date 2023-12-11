namespace LiveNationAPI.Tests;

public class Tests
{
    private RuleEvaluator _evaluator;
    private IRulesFactory _rulesFactory;

    [SetUp]
    public void Setup()
    {
        _rulesFactory = new RulesFactory();
        _evaluator = new RuleEvaluator(_rulesFactory);
    }

    [Test]
    public void EvaluateRule_ForMultiplesOfThree_ShouldOutputLive()
    {
        Assert.That(_evaluator.EvaluateRule(3), Is.EqualTo("Live"));
    }
}