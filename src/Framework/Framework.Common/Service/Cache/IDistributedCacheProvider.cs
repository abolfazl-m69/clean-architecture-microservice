using HumanResource.Framework.Common.Models;
using System.Threading.Tasks;

namespace HumanResource.Framework.Common.Service.Cache
{
    public interface IDistributedCacheProvider
    {
        Task SetAsync<T>(CachingRequest<T> request);
        Task<T> GetAsync<T>(string key);
        Task TryRemove(string key);
    }
}