using MediatR;
using Phusion2.Domain.Core.Commands;
using Phusion2.Domain.Core.Events;
using System.Threading.Tasks;

namespace Phusion2.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<TResponse> SendCommand<T, TResponse>(T command) where T : Command<TResponse>;
        Task RaiseEvent<T>(T @event) where T : Event<Unit>;
    }
}
