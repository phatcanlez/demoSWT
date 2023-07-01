using System.Threading.Tasks;
using CleanArchitecture.Domain.Commands;
using CleanArchitecture.Domain.DomainEvents;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Infrastructure;

public sealed class InMemoryBus : IMediatorHandler
{
    private readonly IMediator _mediator;
    private readonly IDomainEventStore _domainEventStore;

    public InMemoryBus(
        IMediator mediator,
        IDomainEventStore domainEventStore)
    {
        _mediator = mediator;
        _domainEventStore = domainEventStore;
    }

    public Task<TResponse> QueryAsync<TResponse>(IRequest<TResponse> query)
    {
        return _mediator.Send(query);
    }

    public async Task RaiseEventAsync<T>(T @event) where T : DomainEvent
    {
        await _domainEventStore.SaveAsync(@event);

        await _mediator.Publish(@event);
    }

    public Task SendCommandAsync<T>(T command) where T : CommandBase
    {
        return _mediator.Send(command);
    }
}