using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.CacheLibrary.Interfaces
{
    public interface ICache
    {
        Task<T> Get<T>(string cacheKey, Func<Task<T>> retrieveFunction) where T : class;
        Task<T> Reload<T>(string cacheKey, Func<Task<T>> retrieveFunction) where T : class;
        Task Set<T>(string cacheKey, T value) where T : class;
        Task Remove<T>(string cacheKey) where T : class;
    }
}
