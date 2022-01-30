using Microsoft.AspNetCore.Mvc;

namespace CommandApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandController : ControllerBase
{
    private readonly ILogger<CommandController> _logger;

    public CommandController(ILogger<CommandController> logger) => _logger = logger;

    [HttpGet]
    public ActionResult<string> GetCommand()
    {
        _logger.LogInformation("Command");
        return Ok("Command");
    }
}
