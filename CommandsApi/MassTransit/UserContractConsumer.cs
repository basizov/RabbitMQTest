using MassTransit;
using Rabbitmq.Contact;

namespace CommandsApi.MassTransit;

public class UserContractConsumer : IConsumer<UserContract>
{
	private readonly ILogger<UserContractConsumer> _logger;

	public UserContractConsumer(ILogger<UserContractConsumer> logger) => _logger = logger;

	public Task Consume(ConsumeContext<UserContract> context)
	{
		_logger.LogInformation($"Get user with name {context.Message.Name}");
		return Task.CompletedTask;
	}
}
