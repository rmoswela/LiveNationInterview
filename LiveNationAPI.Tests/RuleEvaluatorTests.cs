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
        Assert.That(_evaluator.EvaluateRule(6), Is.EqualTo("Live"));
        Assert.That(_evaluator.EvaluateRule(18), Is.EqualTo("Live"));
    }

    [Test]
    public void EvaluateRule_ForMultiplesOfFive_ShouldOutputNation()
    {
        Assert.That(_evaluator.EvaluateRule(5), Is.EqualTo("Nation"));
        Assert.That(_evaluator.EvaluateRule(10), Is.EqualTo("Nation"));
        Assert.That(_evaluator.EvaluateRule(20), Is.EqualTo("Nation"));
    }

    [Test]
    public void EvaluateRule_ForMultiplesOfBothThreeAndFive_ShouldOutputLiveNation()
    {
        Assert.That(_evaluator.EvaluateRule(15), Is.EqualTo("LiveNation"));
        Assert.That(_evaluator.EvaluateRule(30), Is.EqualTo("LiveNation"));
        Assert.That(_evaluator.EvaluateRule(45), Is.EqualTo("LiveNation"));
    }

    [Test]
    public void EvaluateRule_OtherValues_ShouldOutputThoseOtherValues()
    {
        Assert.That(_evaluator.EvaluateRule(16), Is.EqualTo("16"));
        Assert.That(_evaluator.EvaluateRule(53), Is.EqualTo("53"));
        Assert.That(_evaluator.EvaluateRule(94), Is.EqualTo("94"));
    }
}