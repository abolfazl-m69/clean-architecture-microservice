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
            _kaveNegarApi = new KavenegarApi("6C506279366D7A765656624E78437658416B6E7648773D3D");
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

                var result =await Task.Run(()=> _kaveNegarApi.Send("100074402", request.Destination, request.Body)) ;

                return result.Status == 200;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}