namespace HumanResource.Framework.Core.Events
{
    public interface IEventPublisher
    {
        void Publish<T>(T eventToPublish) where T : IEvent;
    }
}