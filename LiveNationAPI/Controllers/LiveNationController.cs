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
        throw new NotImplementedException();
    }
}
