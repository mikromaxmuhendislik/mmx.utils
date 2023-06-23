using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V7.BaseApplication.Utilies.Convertion;

namespace V7.BaseApplication.Utilies.Helpers
{
    public static class CacheHelpers
    {
        public static async Task<TResult> GetFromCache<TResult>(this IDistributedCache cache, string cacheKey)
        {
            var result = await cache.GetAsync(cacheKey);
            if (result == null) return default;
            return result.FromBytesJson<TResult>();
        }
        public static Task SetT<TValue>(this IDistributedCache cache, string cacheKey, TValue value, int timeInMinutes=240)
        {
            if(value== null)
                throw new ArgumentNullException(nameof(value));
            var data = value.ToBytesJson();
            return cache.SetAsync(cacheKey, data, new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(timeInMinutes)
            });
        }
    }
}
