using HumanResource.Framework.Core.Events;
using System.Collections.Generic;

namespace HumanResource.Framework.Domain
{
    public interface IAggregateRoot
    {
        void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent;
        IReadOnlyList<DomainEvent> GetChanges();
        void ClearChanges();
    }
}