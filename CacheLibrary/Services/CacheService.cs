using Cz.Bkk.Generic.CacheLibrary.Interfaces;
using Cz.Bkk.Generic.Common.IdentityInterfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Bkk.Generic.CacheLibrary.Services
{
    internal class CacheService : ICacheService
    {
        private readonly IMemoryCache cache;
        private readonly ICurrentDateTime currentDateTime;

        public CacheService(IMemoryCache cache, ICurrentDateTime currentDateTime)
        {
            this.cache = cache;
            this.currentDateTime = currentDateTime;
        }

        public T Get<T>(string key) where T : class
        {
            cache.TryGetValue(key, out T cachedResponse);
            return cachedResponse as T;
        }

        public void Set<T>(string key, T value) where T : class
        {
            Set(key, value, currentDateTime.Now.AddDays(1).AddMilliseconds(-1));
        }

        public void Set<T>(string key, T value, DateTimeOffset duration) where T : class
        {
            cache.Set(key, value, duration);
        }

        public void Set<T>(string key, T value, MemoryCacheEntryOptions options) where T : class
        {
            cache.Set(key, value, options);
        }

        public void Clear(string key)
        {
            cache.Remove(key);
        }
    }
}
