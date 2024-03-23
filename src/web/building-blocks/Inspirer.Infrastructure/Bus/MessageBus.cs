using Inspirer.Application.Bus;
using Inspirer.Contracts.Events;
using MassTransit;

namespace Inspirer.Infrastructure.Bus;

/// <summary>
/// Application message bus.
/// </summary>
internal class MessageBus : IMessageBus
{
    private readonly IPublishEndpoint publishEndpoint;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="publishEndpoint">Publish endpoint service.</param>
    public MessageBus(IPublishEndpoint publishEndpoint)
    {
        this.publishEndpoint = publishEndpoint;
    }

    /// <inheritdoc />
    public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
        where TEvent : IIntegrationEvent
    {
        await publishEndpoint.Publish(@event, cancellationToken);
    }
}
