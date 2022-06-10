namespace HumanResource.Framework.Core.Events.UserInfo
{
    public interface IUserInfo
    {
        long ActionUserId { get; set; }
        string UserName { get; set; }
    }
}