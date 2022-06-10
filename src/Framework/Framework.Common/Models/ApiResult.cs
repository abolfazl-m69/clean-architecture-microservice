using Newtonsoft.Json;
using System;
using System.Net;

namespace HumanResource.Framework.Common.Models
{
    public class ApiResult
    {
        public ApiResult(bool isSuccess = false, string message = null)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        [JsonIgnore]
        public HttpStatusCode Status { get; set; }

        public int StatusCode => (int)Status;

        public string Message { get; set; }

        public void Success()
        {
            IsSuccess = true;
            Status = HttpStatusCode.OK;
        }

        public void NotFound(string message = "رکورد پیدا نشد")
        {
            IsSuccess = false;
            Status = HttpStatusCode.NotFound;
            Message = message;
        }

        public void BadRequest(string message = null)
        {
            IsSuccess = false;
            Status = HttpStatusCode.BadRequest;
            Message = message;
        }
        public void ServerError(Exception exception)
        {
            IsSuccess = false;
            Status = HttpStatusCode.InternalServerError;
            Message = exception.Message;
        }
    }

    public class ApiResult<TData> : ApiResult
        where TData : class
    {
        public TData Data { get; set; }

        public ApiResult(bool isSuccess = false, TData data = null, string message = null)
            : base(isSuccess, message)
        {
            Data = data;
        }

        public void Success(TData data)
        {
            IsSuccess = true;
            Status = HttpStatusCode.OK;
            Data = data;
        }
    }
}