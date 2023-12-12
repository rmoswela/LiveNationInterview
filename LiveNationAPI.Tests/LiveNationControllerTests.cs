using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LiveNationAPI.Tests;

public class LiveNationControllerTests
{
    private Mock<IGenerator> _generatorMock;
    private LiveNationController _controller;

    [SetUp]
    public void Setup()
    {
        _generatorMock = new Mock<IGenerator>();
        _controller = new LiveNationController(_generatorMock.Object);
    }

    [Test]
    public void Get_ValidNumberRangeRequest_ShouldReturnOkWithJsonResponse()
    {
        // Arrange
        var numberRangeRequest = new NumberRangeRequestDto
        {
            From = 1,
            To = 15
        };

        var numberRangeResponse = new NumberRangeResponseDto
        {
            Result = "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation",
            Summary = new Summary 
            {
                Live = "4",
                Nation = "2",
                LiveNation = "1",
                Integer = "8"
            }
        };

        _generatorMock.Setup(x => x.GenerateResult(It.Is<NumberRangeRequestDto>(r => r.From == numberRangeRequest.From && r.To == numberRangeRequest.To)))
            .Returns(numberRangeResponse);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var responseJson = JsonSerializer.Serialize(numberRangeResponse, options);

        // Act
        var result = _controller.Get(numberRangeRequest) as ObjectResult;

        // Assert
        Assert.That(result, Is.InstanceOf<IActionResult>());
        Assert.That(result, Is.Not.Null);
        Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        Assert.That(result.Value, Is.EqualTo(responseJson));
    }

    [Test]
    public void Get_InvalidNumberRangeRequest_ShouldReturnBadRequestWithErrorMessage()
    {
        // Arrange
        var numberRangeRequest = new NumberRangeRequestDto
        {
            From = 0,
            To = 10
        };

        var errorMessage = "The values have to be in a range of 1 and greater";

        _generatorMock.Setup(x => x.GenerateResult(It.Is<NumberRangeRequestDto>(r => r.From == numberRangeRequest.From && r.To == numberRangeRequest.To)))
            .Returns(new NumberRangeResponseDto());
        
        // Act
        var result = _controller.Get(numberRangeRequest) as ObjectResult;

        // Assert
        Assert.That(result, Is.InstanceOf<IActionResult>());
        Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.BadRequest));
    }
}
