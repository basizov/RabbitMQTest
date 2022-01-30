using Microsoft.AspNetCore.Mvc;

namespace PlatformApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformController : ControllerBase
{
    private readonly ILogger<PlatformController> _logger;

	public PlatformController(ILogger<PlatformController> logger) => _logger = logger;

	[HttpGet]
    public ActionResult<string> GetPlatforms()
    {
        _logger.LogInformation("Platform");
        return Ok("Platform");
    }
}
