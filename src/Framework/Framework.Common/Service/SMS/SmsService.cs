using System;
using HumanResource.Framework.Common.Models;
using Kavenegar;
using System.Threading.Tasks;

namespace HumanResource.Framework.Common.Service.SMS
{
    public class SmsService : ISmsService
    {
        private readonly KavenegarApi _kaveNegarApi;

        public SmsService()
        {
            _kaveNegarApi = new KavenegarApi("");
        }

        public async Task<bool> SendOtpAsync(SmsRequest request)
        {
            var task = Task.Run(() => _kaveNegarApi.VerifyLookup(request.Destination, request.Body, "verify"));

            var result = await task;

            return result.Status == 200;
        }
        public async Task<bool> SendMessageAsync(SmsRequest request)
        {
            try
            {

                var result =await Task.Run(()=> _kaveNegarApi.Send("", request.Destination, request.Body)) ;

                return result.Status == 200;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}