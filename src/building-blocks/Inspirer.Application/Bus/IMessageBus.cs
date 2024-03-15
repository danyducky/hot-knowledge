using Inspirer.Contracts.Events;

namespace Inspirer.Application.Bus;

/// <summary>
/// Message bus contract.
/// </summary>
public interface IMessageBus
{
    /// <summary>
    /// Publish integration event asynchronously.
    /// </summary>
    /// <param name="event">Integration event instance.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <typeparam name="TEvent">Integration event type.</typeparam>
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken)
        where TEvent : IIntegrationEvent;
}