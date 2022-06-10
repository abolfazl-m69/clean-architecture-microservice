namespace HumanResource.Framework.Core.Events.UserInfo
{
    public interface IEventLookup
    {
        IUserInfo Get();
        void SetUserInfo<T>(T @event) where T : IUserInfo;
    }
}