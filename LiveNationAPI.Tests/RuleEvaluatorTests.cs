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

    [Test]
    public void EvaluateRule_ForMultiplesOfFive_ShouldOutputNation()
    {
        Assert.That(_evaluator.EvaluateRule(5), Is.EqualTo("Nation"));
    }

    [Test]
    public void EvaluateRule_ForMultiplesOfBothThreeAndFive_ShouldOutputLiveNation()
    {
        Assert.That(_evaluator.EvaluateRule(15), Is.EqualTo("LiveNation"));
    }

    [Test]
    public void EvaluateRule_OtherValues_ShouldOutputThoseOtherValues()
    {
        Assert.That(_evaluator.EvaluateRule(16), Is.EqualTo("16"));
    }
}