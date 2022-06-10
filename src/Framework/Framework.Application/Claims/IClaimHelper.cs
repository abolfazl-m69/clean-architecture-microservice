using System.Security.Claims;

namespace HumanResource.Framework.Application.Claims
{
    public interface IClaimHelper
    {
        string GetUserName();
        long GetUserId();
        ClaimsPrincipal GetUserInfo();
    }
}