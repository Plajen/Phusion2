using Phusion2.Domain.Core.Events;
using System;
using FluentValidation.Results;

namespace Phusion2.Domain.Core.Commands
{
    public abstract class Command<T> : Message<T>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
