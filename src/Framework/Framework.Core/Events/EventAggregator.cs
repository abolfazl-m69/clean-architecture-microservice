using System.Collections.Generic;
using System.Linq;

namespace HumanResource.Framework.Core.Events
{
    public class EventAggregator : IEventListener, IEventPublisher
    {
        private readonly List<object> _subscriber = new List<object>();
        public void Publish<T>(T eventToPublish) where T : IEvent
        {
            var handlers = _subscriber.OfType<IEventHandler<T>>().ToList();
            handlers.ForEach(x =>
            {
                x.Handle(eventToPublish);
            });
        }
        public void Subscribe<T>(IEventHandler<T> handler) where T : IEvent
        {
            _subscriber.Add(handler);
        }
        public void UnSubscribe<T>(T eventToPublish) where T : IEvent
        {
            _subscriber.Remove(eventToPublish);
        }
    }
}