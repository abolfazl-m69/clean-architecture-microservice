using System.Security.Claims;
using HumanResource.Framework.Application.Claims;

namespace HumanResource.Framework.Test.Utils
{
    public class ClaimHelperStub : IClaimHelper
    {
        public string GetUserName() => "abolfazl@mousavi";

        public string GetFirstName() => "abolfazl";

        public string GetLastName() => "mousavi";

        public long GetUserId() => 10;

        public ClaimsPrincipal? GetUserInfo() => null!;
    }
}