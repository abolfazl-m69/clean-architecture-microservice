using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using HumanResource.Framework.Core.Events.UserInfo;

namespace HumanResource.Framework.Application.Claims
{
    public class ClaimHelper : IClaimHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEventLookup _eventLookup;

        public ClaimHelper(IHttpContextAccessor httpContextAccessor, IEventLookup eventLookup)
        {
            _httpContextAccessor = httpContextAccessor;
            _eventLookup = eventLookup;
        }
        public ClaimsPrincipal GetUserInfo()
        {
            return _httpContextAccessor.HttpContext?.User;
        }

        public long GetUserId()
        {
            var claims = GetUserClaims();
            var userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value;
            return Convert.ToInt64(userId);
        }

        private IEnumerable<Claim> GetUserClaims()
        {
            return _httpContextAccessor.HttpContext is null ? GetEventLookupUserInfo().Claims.ToList() : _httpContextAccessor.HttpContext.User.Claims.ToList();
        }

        /// <summary>
        /// for event bus message
        /// </summary>
        /// <returns></returns>
        private ClaimsPrincipal GetEventLookupUserInfo()
        {
            var userInfo = _eventLookup.Get();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, userInfo.ActionUserId.ToString()),
                new Claim(ClaimTypes.Name, userInfo.UserName)
            };

            var user = new ClaimsPrincipal();
            var claimsIdentity = new ClaimsIdentity(claims, "Bearer");
            user.AddIdentity(claimsIdentity);

            return user;

        }

        public string GetUserName()
        {
            var claims = GetUserClaims();
            return claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        }

    }
}