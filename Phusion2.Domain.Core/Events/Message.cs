using MediatR;
using System;

namespace Phusion2.Domain.Core.Events
{
    public abstract class Message<T> : IRequest<T>
    {
        public string MessageType { get; protected set; }
        public Guid CorrelationId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
