using Microsoft.Extensions.Caching.Memory;
using System;

namespace Cz.Bkk.Generic.CacheLibrary.Interfaces
{
    public interface ICacheService
    {
        T Get<T>(string key) where T : class;
        void Set<T>(string key, T value) where T : class;
        void Set<T>(string key, T value, DateTimeOffset duration) where T : class;
        void Set<T>(string key, T value, MemoryCacheEntryOptions options) where T : class;
        void Clear(string key);
    }
}
