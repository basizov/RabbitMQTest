using MassTransit.Definition;
using Rabbitmq.Contact;

namespace CommandsApi.MassTransit;

public class UserContractConsumerDefinition : ConsumerDefinition<UserContractConsumer>
{
	public UserContractConsumerDefinition() => EndpointName = Constatns.QueueName;
}
