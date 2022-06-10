using System;

namespace HumanResource.Framework.Core
{
    public class BusinessException : Exception
    {
        public long Code { get; private set; }
        public BusinessException(long code, string message) : base(message)
        {
            Code = code;
        }
    }
}