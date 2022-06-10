using HumanResource.Framework.Common.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HumanResource.Framework.Common.Service.Cache
{
    public class DistributedCacheProvider : IDistributedCacheProvider
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheProvider(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetAsync<T>(CachingRequest<T> request)
        {
            if (request is null)
            {
                throw new ArgumentNullException();
            }

            var serializedData = JsonConvert.SerializeObject(request.Value);

            await _cache.SetAsync(request.Key, Encoding.UTF8.GetBytes(serializedData), new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = request.ExpireTime
            });
        }

        public async Task<T> GetAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException();
            }

            var data = await _cache.GetAsync(key);

            return data is null ? default : JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(data));
        }

        public async Task TryRemove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException();
            }

            await _cache.RemoveAsync(key);
        }
    }
}