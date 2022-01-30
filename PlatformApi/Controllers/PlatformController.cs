using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Rabbitmq.Contact;

namespace PlatformApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformController : ControllerBase
{
	private readonly ILogger<PlatformController> _logger;
	private readonly IPublishEndpoint _publishEndpoint;

	public PlatformController(ILogger<PlatformController> logger, IPublishEndpoint publishEndpoint)
	{
		_logger = logger;
		_publishEndpoint = publishEndpoint;
	}

	[HttpGet]
	public async Task<ActionResult<string>> GetPlatforms()
	{
		_logger.LogInformation("Send rabbitmq message");
		await _publishEndpoint.Publish<UserContract>(new()
		{
			Name = "Successfule User Testing!!"
		});
		return Ok("Platform");
	}
}
