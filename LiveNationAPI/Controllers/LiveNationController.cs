using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace LiveNationAPI;

[ApiController]
[Route("api/[controller]")]
public class LiveNationController : ControllerBase
{
    private readonly IGenerator _generator;

    public LiveNationController(IGenerator generator)
    {
        _generator = generator;
    }

    public IActionResult Get(NumberRangeRequestDto numberRangeRequest)
    {
        var response = _generator.GenerateResult(numberRangeRequest);

        var options = new JsonSerializerOptions {
          WriteIndented = true
        };

        var jsonResponse = JsonSerializer.Serialize(response, options);

        return Ok(jsonResponse);
    }
}
