using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Caching
{
    public class CacheService<T> : ICacheService<T>
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        //-------------------------------------------------------
        public async Task<T> GetAsync(string cacheKey)
        {
            //TODO - Log
            //T result;
            return await Task.Run(() =>
            {
                _cache.TryGetValue(cacheKey, out T entry);
                return entry;
            });
            //return Task.FromResult(result);
        }

        public async Task SetAsync(string cacheKey, T value, TimeSpan duration)
        {
            //TODO - Log
            await Task.Run(() =>
             _cache.Set(
                 cacheKey,
                 value,
                 new MemoryCacheEntryOptions().SetAbsoluteExpiration(duration)
                 )
             );

        }

        public async void DeleteAsync(string cacheKey)
        {
            await Task.Run(() => _cache.Remove(cacheKey));
        }

       

    }
}
