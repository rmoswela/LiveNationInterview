using Moq;

namespace LiveNationAPI.Tests;

public class GeneratorTests
{
    private Generator _generator;
    private Mock<ICacheService> _cacheServiceMock;
    private Mock<IRuleEvaluator> _ruleEvaluatorMock;

    [SetUp]
    public void Setup()
    {
        _cacheServiceMock = new Mock<ICacheService>();
        _ruleEvaluatorMock = new Mock<IRuleEvaluator>();
        _generator = new Generator(_cacheServiceMock.Object, _ruleEvaluatorMock.Object);
    }

    [Test]
    public void GenerateResult_CachedValueExists_ReturnsCachedValue()
    {
        // Arrange
        var request = new NumberRangeRequestDto { From = 1, To = 10 };
        var cachedResponse = new NumberRangeResponseDto 
        {
            Result = "1 2 Live 4 Nation Live 7 8 Live Nation",
            Summary = new Summary 
            {
                Live = "3",
                Nation = "2",
                LiveNation = "0",
                Integer = "5"
            }
        };

        _cacheServiceMock.Setup(c => c.GetCachedValue(It.IsAny<string>())).Returns(cachedResponse);

        // Act
        var result = _generator.GenerateResult(request);

        // Assert
        Assert.That(result, Is.EqualTo(cachedResponse));
        _cacheServiceMock.Verify(c => c.GetCachedValue(It.IsAny<string>()), Times.Once);
        _cacheServiceMock.Verify(c => c.SetCacheValue(It.IsAny<NumberRangeResponseDto>(), It.IsAny<string>()), Times.Never);
    }
}
