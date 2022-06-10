using HumanResource.Framework.Core.Events.UserInfo;
using System.Collections.Generic;
using System.Security.Claims;

namespace HumanResource.Framework.Application.Claims
{
    public class MessageClaimHelper : IClaimHelper
    {
        private readonly IEventLookup _eventLookup;

        public MessageClaimHelper(IEventLookup eventLookup)
        {
            _eventLookup = eventLookup;
        }

        public string GetLastName()
        {
            return null;
        }

        public long GetUserId()
        {
            var userInfo = _eventLookup.Get();
            return userInfo.ActionUserId;
        }
        public ClaimsPrincipal GetUserInfo()
        {
            var userInfo = _eventLookup.Get();
            var claims = new List<Claim>
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userInfo.ActionUserId.ToString()),
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givename", userInfo.UserName)
            };

            var user = new ClaimsPrincipal();
            var claimsIdentity = new ClaimsIdentity(claims, "Bearer");
            user.AddIdentity(claimsIdentity);

            return user;

        }

        public string GetUserName()
        {
            var userInfo = _eventLookup.Get();
            return userInfo.UserName;
        }

        public string GetFirstName()
        {
            return null;
        }
    }
}