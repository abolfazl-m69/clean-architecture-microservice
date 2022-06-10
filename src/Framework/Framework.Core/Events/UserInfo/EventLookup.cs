using System.Collections.Generic;
using System.Security.Claims;

namespace HumanResource.Framework.Core.Events.UserInfo
{
    public class EventLookup : IEventLookup
    {
        private IUserInfo _userInfo;
        public IUserInfo Get()
        {
            return _userInfo;
        }
        public void SetUserInfo<T>(T @event) where T : IUserInfo
        {
            _userInfo = @event;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, _userInfo.ActionUserId.ToString()),
                new Claim(ClaimTypes.Name, _userInfo.UserName)
            };

            var user = new ClaimsPrincipal();
            var claimsIdentity = new ClaimsIdentity(claims, "Bearer");
            user.AddIdentity(claimsIdentity);
        }
    }
}