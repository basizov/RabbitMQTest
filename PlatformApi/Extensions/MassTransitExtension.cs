using MassTransit;
using MassTransit.Definition;

namespace PlatformApi.Extensions;

public static class MassTransitExtension
{
	public static IServiceCollection AddMassTransitConnection(this IServiceCollection services, IConfiguration config)
	{
		var massTransitSection = config.GetSection("MassTransit");
		var url = massTransitSection.GetValue<string>("Url");
		var host = massTransitSection.GetValue<string>("Host");
		var userName = massTransitSection.GetValue<string>("UserName");
		var password = massTransitSection.GetValue<string>("Password");

		services.AddMassTransit(opt =>
		{
			opt.AddBus(busFactory =>
			{
				var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
				{
					cfg.Host($"rabbitmq://{url}/{host}", configurator =>
					{
						configurator.Username(userName);
						configurator.Password(password);
					});
					cfg.ConfigureEndpoints(busFactory, SnakeCaseEndpointNameFormatter.Instance);
					cfg.UseRawJsonSerializer();
				});

				return bus;
			});
		});
		services.AddMassTransitHostedService();
		return services;
	}
}
