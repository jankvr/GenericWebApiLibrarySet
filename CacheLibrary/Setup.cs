using Cz.Bkk.Generic.CacheLibrary.Interfaces;
using Cz.Bkk.Generic.CacheLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Bkk.Generic.CacheLibrary
{
    public static class Setup
    {
        /// <summary>
        /// Dependencies
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddSingleton<ICache, Cache>();
            services.AddSingleton<ICacheService, CacheService>();
        }
    }
}
