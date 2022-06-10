namespace HumanResource.Framework.Core.Events
{
    public interface IEventListener
    {
        void Subscribe<T>(IEventHandler<T> handler) where T : IEvent;
    }
}