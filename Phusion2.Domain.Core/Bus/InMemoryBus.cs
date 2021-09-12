using MediatR;
using Phusion2.Domain.Core.Commands;
using Phusion2.Domain.Core.Events;
using System.Threading.Tasks;

namespace Phusion2.Domain.Core.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> SendCommand<T, TResponse>(T command) where T : Command<TResponse>
        {
            return await _mediator.Send(command);
        }

        public async Task RaiseEvent<T>(T @event) where T : Event<Unit>
        {
            await _mediator.Publish(@event);
        }
    }
}
