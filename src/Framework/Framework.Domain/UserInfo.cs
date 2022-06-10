namespace HumanResource.Framework.Domain
{
    public class UserInfo
    {
        public long UserId { get; private set; }
        public string UserName { get; private set; }

        public UserInfo(long userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
        protected UserInfo() { }
    }
}