using HumanResource.Framework.Common.Extensions;
using HumanResource.Framework.Common.GlobalExceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace HumanResource.Framework.Common.Service.UserClaims
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            if (_httpContextAccessor.HttpContext?.User != null)
                return (Guid)_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier).ToGuid();
            throw new UserNotFoundException();
        }

        public string GetUserName()
        {
            if (_httpContextAccessor.HttpContext?.User != null)
                return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
            throw new UserNotFoundException();
        }
    }
}