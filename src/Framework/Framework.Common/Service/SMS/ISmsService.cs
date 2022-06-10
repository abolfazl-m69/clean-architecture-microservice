using HumanResource.Framework.Common.Models;
using System.Threading.Tasks;

namespace HumanResource.Framework.Common.Service.SMS
{
    public interface ISmsService
    {
        Task<bool> SendOtpAsync(SmsRequest request);
        Task<bool> SendMessageAsync(SmsRequest request);
    }
}