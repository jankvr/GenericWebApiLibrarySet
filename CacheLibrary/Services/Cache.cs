using Cz.Bkk.Generic.CacheLibrary.Interfaces;
using Cz.Bkk.Generic.Common.Models.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.CacheLibrary.Services
{
    internal class Cache : ICache
    {
        private readonly ICacheService cacheService;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 10);

        public Cache(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public async Task<T> Get<T>(string cacheKey, Func<Task<T>> retrieveFunction) where T : class
        {
            var data = cacheService.Get<T>(cacheKey);

            if (data != null)
            {
                return data;
            }

            try
            {
                await semaphore.WaitAsync();

                // The key of this Get duplication is that we have to make sure it hasn't been repopulated when we were locked.
                data = cacheService.Get<T>(cacheKey);
                if (data != null)
                {
                    return data;
                }

                if (retrieveFunction != null)
                {
                    data = await retrieveFunction();
                    cacheService.Set(cacheKey, data);
                }
            }
            finally
            {
                semaphore.Release();
            }

            return data;
        }

        public async Task<T> Reload<T>(string cacheKey, Func<Task<T>> retrieveFunction) where T : class
        {
            T retrievedData = null;

            try
            {
                await semaphore.WaitAsync();

                if (retrieveFunction != null)
                {
                    cacheService.Clear(cacheKey);
                    retrievedData = await retrieveFunction();
                    cacheService.Set(cacheKey, retrievedData);
                }
            }
            finally
            {
                semaphore.Release();
            }

            return retrievedData;
        }

        public async Task Set<T>(string cacheKey, T value) where T : class
        {
            var data = cacheService.Get<T>(cacheKey);

            if (data != null)
            {
                throw new CacheAlreadySetException();
            }

            try
            {
                await semaphore.WaitAsync();

                // The key of this Get duplication is that we have to make sure it hasn't been repopulated when we were locked.
                data = cacheService.Get<T>(cacheKey);
                if (data != null)
                {
                    throw new CacheAlreadySetException();
                }

                cacheService.Set(cacheKey, value);
            }
            finally
            {
                semaphore.Release();
            }
        }

        public async Task Remove<T>(string cacheKey) where T : class
        {
            var data = cacheService.Get<T>(cacheKey);

            if (data == null)
            {
                throw new NoCacheKeyFoundException();
            }

            try
            {
                await semaphore.WaitAsync();

                // The key of this Get duplication is that we have to make sure it hasn't been repopulated when we were locked.
                data = cacheService.Get<T>(cacheKey);
                if (data == null)
                {
                    throw new NoCacheKeyFoundException();
                }

                cacheService.Clear(cacheKey);
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
