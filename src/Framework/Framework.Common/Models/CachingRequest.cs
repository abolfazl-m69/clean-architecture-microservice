using System;

namespace HumanResource.Framework.Common.Models
{
    public class CachingRequest<T>
    {
        public string Key { get; set; }
        public T Value { get; set; }
        public TimeSpan ExpireTime { get; set; }
    }
}