using System.Security.Claims;
using HumanResource.Framework.Application.Claims;

namespace HumanResource.Framework.Test.Utils
{
    public class ClaimHelperStub : IClaimHelper
    {
        public string GetUserName() => "John@22";

        public string GetFirstName() => "John";

        public string GetLastName() => "Lando";

        public long GetUserId() => 10;

        public ClaimsPrincipal? GetUserInfo() => null!;
    }
}