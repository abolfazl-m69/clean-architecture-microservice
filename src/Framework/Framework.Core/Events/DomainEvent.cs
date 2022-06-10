using System;

namespace HumanResource.Framework.Core.Events
{
    public class DomainEvent : IEvent
    {
        public Guid EventId { get; set; }
        public DateTime DateTimePublish { get; set; }

        protected DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            DateTimePublish = DateTime.Now;
        }
    }
}