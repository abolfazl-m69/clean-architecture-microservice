using HumanResource.Framework.Core.Events;
using System.Collections.Generic;

namespace HumanResource.Framework.Test.Utils
{
    public class FakeEventPublisher : IEventPublisher
    {
        private readonly List<object> _publishedEvents;
        public FakeEventPublisher() => _publishedEvents = new List<object>();

        public void ClearHistory() => _publishedEvents.Clear();

        public List<object> GetPublishedEvents() => _publishedEvents;

        public TEvent? GetIndex<TEvent>(int index) where TEvent : class, IEvent => _publishedEvents[index] as TEvent;

        public TEvent? GetLastEvent<TEvent>() where TEvent : class, IEvent => _publishedEvents[^1] as TEvent;

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent => _publishedEvents.Add(@event);
    }
}