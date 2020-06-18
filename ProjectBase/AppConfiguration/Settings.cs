using System;
using System.Collections.Generic;
using System.Text;

namespace Cz.Bkk.Generic.ProjectBase.AppConfiguration
{
    /// <summary>
    /// Configuration settings
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Configuration map
        /// </summary>
        public Dictionary<string, string> AppConfiguration { get; set; }

        /// <summary>
        /// Injected constructor
        /// </summary>
        public Settings()
        {
            this.AppConfiguration = new Dictionary<string, string>();
        }

        /// <summary>
        /// Returning value for requested configuration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetValue<T>(string key) where T : class
        {
            try
            {
                // Try to find it in AppConfiguration.
                return AppConfiguration[key] as T;
            }
            // If the given key is not present in the map, the exception will be thrown. Return null then.
            catch (Exception) 
            { 
                /*Empty for now*/ 
            }
            return null;
        }
    }
}
