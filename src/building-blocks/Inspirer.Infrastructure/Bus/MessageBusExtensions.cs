using System.Reflection;
using Inspirer.Application.Bus;
using Inspirer.Infrastructure.Options;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Inspirer.Infrastructure.Bus;

/// <summary>
/// Services extensions for <see cref="MessageBus"/>.
/// </summary>
internal static class MessageBusExtensions
{
    /// <summary>
    /// Add a message bus implementation.
    /// </summary>
    /// <param name="services">Services collection.</param>
    /// <param name="options">Rabbit MQ options.</param>
    /// <param name="consumerAssembly">Reference to consumer assembly.</param>
    public static void AddMessageBus(this IServiceCollection services, RabbitMqOptions options, Assembly consumerAssembly)
    {
        services.AddMassTransit(options, consumerAssembly);
        services.AddScoped<IMessageBus, MessageBus>();
    }

    private static void AddMassTransit(this IServiceCollection services, RabbitMqOptions options, Assembly consumerAssembly)
    {
        services.AddMassTransit(opt =>
        {
            opt.AddConsumers(consumerAssembly);

            opt.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(options.Host,
                    host =>
                    {
                        host.Username(options.UserName);
                        host.Password(options.Password);
                    }
                );

                cfg.ReceiveEndpoint(options.ExchangeName,
                    exchange =>
                    {
                        exchange.ConfigureConsumers(context);
                    }
                );
            });
        });
    }
}
