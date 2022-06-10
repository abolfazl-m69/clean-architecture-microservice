using HumanResource.Framework.Core.Events;
using HumanResource.Framework.Core.Utilities;
using System;
using System.Collections.Generic;

namespace HumanResource.Framework.Domain
{
    public class AggregateRootBase<TKey> : BaseEntity<TKey>, IAggregateRoot
    {
        private IEventPublisher _publisher;
        private readonly List<DomainEvent> _publishedEvents = new List<DomainEvent>();
        public AggregateRootBase() { }
        public DateTime CreateOn { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? ActionTime { get; private set; }
        public long ActionUserId { get; private set; }
        public string ActionUserName { get; set; }
        public bool IsActive { get; private set; }
        public byte[] RowVersion { get; private set; }
        protected void SetUserActionLog(IClock clock, long userActionId,string actionUserName)
        {
            ActionTime = clock.Now();
            ActionUserId = userActionId;
            this.ActionUserName = actionUserName;

        }
        protected void SetIsDeletedToTrue()
        {
            IsDeleted = true;
        }
        protected void SetIsActiveToDeactivate()
        {
            IsActive = false;
        }
        protected void SetIsActiveToActive()
        {
            IsActive = true;
        }

        protected void Recovery()
        {
            IsDeleted = false;
        }
        protected AggregateRootBase(TKey id, IClock clock, IEventPublisher publisher, long actionUserId,string actionUserName) : base(id)
        {
            this.CreateOn = clock.Now();
            this._publisher = publisher;
            this.ActionUserId = actionUserId;
            this.IsActive = true;
            this.IsDeleted = false;
            this.ActionUserName = actionUserName;
        }

        public void SetPublisher(IEventPublisher publisher)
        {
            this._publisher = publisher;
        }
        public void Publish<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            this._publishedEvents.Add(@event);
            _publisher.Publish(@event);
        }

        public IReadOnlyList<DomainEvent> GetChanges()
        {
            return this._publishedEvents;
        }

        public void ClearChanges()
        {
            this._publishedEvents.Clear();
        }
    }
}