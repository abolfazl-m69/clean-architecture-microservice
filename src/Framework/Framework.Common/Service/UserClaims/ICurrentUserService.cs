using System;

namespace HumanResource.Framework.Common.Service.UserClaims
{
    public interface ICurrentUserService
    {
        Guid GetUserId();
    }
}